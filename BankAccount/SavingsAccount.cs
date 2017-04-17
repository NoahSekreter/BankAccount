using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class SavingsAccount : Account
    {
        public SavingsAccount(string name, int number) : base(name, number)
        {

        }
        public override void AccountInfo()
        {
            Console.WriteLine("Account Type: Savings Account");
            base.AccountInfo();
        }
        public override void Deposit(float money)
        {
            Console.WriteLine("Depositing $" + money.ToString("0.00") + " into your savings account.");
            base.Deposit(money);
        }
        public override void Withdraw(float money)
        {
            if (money > balance)
            {
                Console.WriteLine("Transaction failed, you lack the funds to withdraw that amount");
            }
            else
            {
                Console.WriteLine("Withdrawing $" + money.ToString("0.00") + " from your savings account.");
                base.Withdraw(money);
            }
        }
    }
}
