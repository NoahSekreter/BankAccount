using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    abstract class Account
    {
        protected string name;
        protected int number;
        protected float balance;

        public string Name { get { return name; } }
        public float Balance { get { return balance; } }

        public Account(string name, int number)
        {
            this.name = name;
            this.number = number;
        }

        public void NameInfo()
        {
            Console.WriteLine("Name: " + name);
        }

        public virtual void AccountInfo()
        {
            Console.WriteLine("Current Balance: " + balance.ToString("$0.00"));
            Console.WriteLine("Account Number: " + number.ToString("0000"));
        }

        public virtual void Deposit(float money)
        {
            balance += money;
            Console.WriteLine("Your current balance is now " + balance.ToString("$0.00"));
        }
        public virtual void Withdraw(float money)
        {
            balance -= money;
            Console.WriteLine("Your current balance is now " + balance.ToString("$0.00"));
        }
    }
}
