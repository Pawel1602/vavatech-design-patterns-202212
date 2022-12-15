using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Models
{
    public class BankAccount
    {
        private decimal balance;

        private const decimal overdraftLimit = -500;

        public decimal GetBalance()
        {
            return balance;
        }

        public void Deposit(decimal amount)
        {
            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (balance - amount >= overdraftLimit)
            {
                balance -= amount;
            }
            else
            {
                throw new ApplicationException();
            }
        }


    }
}
