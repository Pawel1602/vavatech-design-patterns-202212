using Stateless;
using System;
using System.Diagnostics.Tracing;
using System.Net.Http.Headers;

namespace StateMachinePattern
{
    // dotnet add package Stateless

    // Context
    public class Order
    {
        private StateMachine<OrderStatus, OrderTrigger> machine = new StateMachine<OrderStatus, OrderTrigger>(OrderStatus.Pending);

        public Order(OrderStatus initialState = OrderStatus.Pending)
        {
            Id = Guid.NewGuid();
            OrderDate = DateTime.Now;

            machine.Configure(OrderStatus.Pending)
                .PermitIf(OrderTrigger.Confirm, OrderStatus.Completion, ()=>IsPaid, "Is Paid")
                .Permit(OrderTrigger.Cancel, OrderStatus.Cancelled);

            machine.Configure(OrderStatus.Completion)
                .Permit(OrderTrigger.Confirm, OrderStatus.Sent)
                .Permit(OrderTrigger.Cancel, OrderStatus.Cancelled);

            machine.Configure(OrderStatus.Sent)
                .OnEntry(() => Console.WriteLine($"Your order {Id} was sent."), "Send message")
                .Permit(OrderTrigger.Confirm, OrderStatus.Delivered)     
                .Ignore(OrderTrigger.Cancel);

            machine.Configure(OrderStatus.Delivered)
                .OnEntry(() => Console.WriteLine($"Your order {Id} was delivered."), "Send message")
                .Permit(OrderTrigger.Confirm, OrderStatus.Completed)
                .Permit(OrderTrigger.Cancel, OrderStatus.Cancelled);

        }

        public string Graph => Stateless.Graph.UmlDotGraph.Format(machine.GetInfo());

        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        // public OrderStatus Status { get; private set; }

        public OrderStatus Status => machine.State;

        public bool IsPaid { get; set; }

        public void Confirm() => machine.Fire(OrderTrigger.Confirm);

        public void Cancel() => machine.Fire(OrderTrigger.Cancel);
       
        public override string ToString() => $"Order {Id} created on {OrderDate}{Environment.NewLine}";

        public virtual bool CanConfirm => machine.CanFire(OrderTrigger.Confirm);
        public virtual bool CanCancel => machine.CanFire(OrderTrigger.Cancel);
    }

    public enum OrderStatus
    {
        Pending,
        Completion,
        Sent,
        Delivered,
        Completed,
        Cancelled

    }

    public enum OrderTrigger
    {
        Confirm,
        Cancel,
    }
}

namespace StatePattern
{
    // Abstract State
    public abstract class OrderState
    {
        // Handle
        public abstract void Confirm(OrderProxy order);
        // Handle
        public abstract void Cancel(OrderProxy order);

        public abstract bool CanConfirm { get; }

        public abstract bool CanCancel { get; }
    }

    // Concrete State
    public class Pending : OrderState
    {
        public override bool CanConfirm => true;

        public override bool CanCancel => true;

        // Handle
        public override void Confirm(OrderProxy order)
        {
            if (order.IsPaid)
            {
                order.State = new Completion();
            }            
        }

        // Handle
        public override void Cancel(OrderProxy order)
        {
            order.State = new Cancelled();
        }       
    }

    public class Completion : OrderState
    {
        public override bool CanConfirm => true;

        public override bool CanCancel => true;

        public override void Cancel(OrderProxy order)
        {
            order.State = new Cancelled();
        }

        public override void Confirm(OrderProxy order)
        {
            order.State = new Sent();
            Console.WriteLine($"Your order {order.Id} was sent.");
        }
    }

    // Concrete State
    public class Sent : OrderState
    {
        public override bool CanConfirm => true;
        public override bool CanCancel => false;

        public override void Confirm(OrderProxy order)
        {
            order.State = new Delivered();
            Console.WriteLine($"Your order {order.Id} was delivered.");
        }

        public override void Cancel(OrderProxy order)
        {
            throw new InvalidOperationException();
        }
    }

    public class Delivered : OrderState
    {
        public override bool CanConfirm => true;

        public override bool CanCancel => true;

        public override void Confirm(OrderProxy order)
        {            
            order.State = new Completed();
        }

        public override void Cancel(OrderProxy order)
        {
            order.State = new Cancelled();
        }
    }

    public class Completed : OrderState
    {
        public override bool CanConfirm => false;

        public override bool CanCancel => false;

        public override void Confirm(OrderProxy order)
        {
            throw new InvalidOperationException();
        }

        public override void Cancel(OrderProxy order)
        {
            throw new InvalidOperationException();
        }       
    }

    public class Cancelled : OrderState
    {
        public override bool CanConfirm => false;
        public override bool CanCancel => false;

        public override void Cancel(OrderProxy order)
        {
            throw new InvalidOperationException();
        }

        public override void Confirm(OrderProxy order)
        {
            throw new InvalidOperationException();
        }
    }

    public class Customer
    {

    }

    public class OrderProxy : Order
    {
        public OrderState State { get; set; }

        public override void Confirm() => State.Confirm(this);

        public override void Cancel() => State.Cancel(this);

        public override bool CanConfirm => State.CanConfirm;
        public override bool CanCancel => State.CanCancel;

        public OrderProxy()
          : this(new Pending())
        {
        }

        public OrderProxy(OrderState initialState)
            : base()
        {            
            State = initialState;
        }
    }

    // Context
    public class Order
    {
        public Customer Customer { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
            OrderDate = DateTime.Now;            
        }

        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
      

        public bool IsPaid { get; set; }

        public virtual void Confirm() { }

        public virtual void Cancel() { }

        public override string ToString() => $"Order {Id} created on {OrderDate}{Environment.NewLine}";

        public virtual bool CanConfirm => false;
        public virtual bool CanCancel => false;
    }

}
