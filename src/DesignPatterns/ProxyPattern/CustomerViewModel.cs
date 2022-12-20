using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    public interface ICommand
    {
        void Execute();
        bool CanExecute();
    }

    public class RelayCommand : ICommand
    {
        private readonly Action execute;

        public RelayCommand(Action execute)
        {
            this.execute = execute;
        }

        public bool CanExecute()
        {
            return true;
        }

        public void Execute()
        {
            execute?.Invoke();
        }
    }

    // https://docs.devexpress.com/WPF/17352/mvvm-framework/viewmodels/runtime-generated-poco-viewmodels
    internal class CustomerViewModelProxy : CustomerViewModel
    {
        public ICommand SendCommand { get; set; }

        public CustomerViewModelProxy()
        {
            SendCommand = new RelayCommand(() => Send());
        }

        public override void Send()
        {
            base.Send();
        }
    }

    internal class CustomerViewModel
    {
        public Customer SelectedCustomer { get; set; }

        public CustomerViewModel()
        {
           
        }

        public virtual void Send()
        {
            Console.WriteLine($"Send email to {SelectedCustomer}");
        }
    }
}
