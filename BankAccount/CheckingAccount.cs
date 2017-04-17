using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class CheckingAccount : Account
    {
        public CheckingAccount(string name, int number) : base(name, number)
        {
            
        }
        public override void AccountInfo()
        {
            Console.WriteLine("Account Type: Checking Account");
            base.AccountInfo();
        }
        public override void Deposit(float money)
        {
            Console.WriteLine("Depositing $" + money.ToString("0.00") + " into your checking account.");
            base.Deposit(money);
        }
        public override void Withdraw(float money)
        {
            Console.WriteLine("Withdrawing $" + money.ToString("0.00") + " from your checking account.");
            base.Withdraw(money);
        }
    }
}
