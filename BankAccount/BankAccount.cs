using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }

        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        private List<Transaction> allTransactions = new List<Transaction>();
        private static int accountNumberSeed = 1234567890;
        private readonly decimal _minimumBalance;

        public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) {        
        }

        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
        {
            Owner = name;
            _minimumBalance = minimumBalance;

            Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            if(initialBalance > 0)
                MakeDeposit(initialBalance, DateTime.Now, "Balance inicial");
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "La cantidad de depósito tiene que ser positivo");
            }

            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "La cantidad de depósito tiene que ser positivo");
            }

            var overdraftTransaction = CheckWithdrawlLimit(Balance - amount < _minimumBalance);
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);

            if (overdraftTransaction != null)
                allTransactions.Add(overdraftTransaction);
        }

        protected virtual Transaction CheckWithdrawlLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                throw new InvalidOperationException("No tienes suficientes fondos");
            }
            else
            {
                return default;
            }
        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder();
            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNotes");
            foreach (var transaction in allTransactions)
            {
                balance += transaction.Amount;
                report.AppendLine($"{transaction.Date.ToShortDateString()}\t{transaction.Amount}\t{balance}\t{transaction.Notes}");
            }

            return report.ToString();
        }

        public virtual void PerformMonthEndTransactions()
        {
        }
    }
}