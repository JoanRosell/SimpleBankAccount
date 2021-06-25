using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Account
    {
        decimal _balance;

        // Constructors
        public Account()
        {
            Balance = decimal.Zero;
        }

        public Account(decimal balance)
        {
            Balance = balance;
        }

        public decimal Balance
        {
            get => _balance;
            private set
            {
                if (value >= decimal.Zero)
                {
                    _balance = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public decimal Withdraw(decimal amount)
        {
            if (amount <= this.Balance)
            {
                this.Balance -= amount;
                return amount;
            }

            throw new InvalidOperationException($"Required amount not available, your current balance is {this.Balance}.");
        }

        public void Deposit(decimal amount)
        {
            checked
            {
                this.Balance += amount;
            }
        }
    }
}
