using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Client
    {
        SavingsAccount savings;
        CheckingAccount checking;
        private string name;
        private Random r;

        public string Name
        {
            get { return name; }
        }
        public SavingsAccount Savings
        {
            get { return savings; }
        }
        public CheckingAccount Checking
        {
            get { return checking; }
        }

        public Client(string name)
        {
            this.name = name;
            //Generates a random 4-digit account number for each account
            r = new Random();
            savings = new SavingsAccount(name, r.Next(0,9999));
            checking = new CheckingAccount(name, r.Next(0, 9999));
        }
        public void ClientInfo()
        {
            Console.WriteLine("Client Information");
            Console.WriteLine("Name: " + name);
        }
        public void AccountInfo(string str)
        {
            //Is answer a?
            if (str.ToLower() == "a")
            {
                checking.AccountInfo();
            }
            //Is it b?
            else if (str.ToLower() == "b")
            { 
                savings.AccountInfo();
            }
            //Not a valid answer
            else
            {
                Console.WriteLine("I'm sorry, that's not a valid answer.\n");
            }
        }
    }
}
