using System;
using System.Diagnostics.Tracing;

namespace StatePattern
{
    public class Order
    {

        public Order(OrderStatus initialState = OrderStatus.Pending)
        {            
            Id = Guid.NewGuid();
            OrderDate = DateTime.Now;
            Status = initialState;
        }

        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; private set; }

        public void Confirm()
        {
            if (Status == OrderStatus.Pending)
            {
                Status = OrderStatus.Sent;
            }
            else if (Status == OrderStatus.Sent)
            {
                Status = OrderStatus.Delivered;
            }
            else if (Status == OrderStatus.Delivered)
            {
                Status = OrderStatus.Completed;
            }
            else
            {
                throw new InvalidOperationException();
            }

        }

        public void Cancel()
        {
            if (Status == OrderStatus.Pending)
            {
                Status = OrderStatus.Cancelled;
            }
            else if (Status == OrderStatus.Delivered)
            {
                Status = OrderStatus.Cancelled;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public override string ToString() => $"Order {Id} created on {OrderDate}{Environment.NewLine}";

        public virtual bool CanConfirm => Status == OrderStatus.Pending || Status == OrderStatus.Sent || Status == OrderStatus.Delivered;
        public virtual bool CanCancel => Status == OrderStatus.Pending || Status == OrderStatus.Delivered;
    }

    public enum OrderStatus
    {
        Pending,        
        Sent,
        Delivered,
        Completed,
        Cancelled

    }

}
