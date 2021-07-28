using System;

namespace MyBank
{
    public class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
        {
        }

        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                var interest = -Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.Now, "Cargo de interes mensual");
            }
        }

        protected override Transaction CheckWithdrawlLimit(bool isOverdrawn) => isOverdrawn ? new Transaction(-20, DateTime.Now, "Cargo por sobregiro") : default;
    }
}