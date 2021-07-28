using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance { get {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }
        private List<Transaction> allTransactions { get; set; } = new List<Transaction>();

        private static int accountNumberSeed = 1234567890;

        public BankAccount(string name, decimal initialBalance) {
            Owner = name;

            MakeDeposit(initialBalance, DateTime.Now, "Balance inicial");

            Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note) {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "La cantidad de depósito tiene que ser positivo");
            }

            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note) {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "La cantidad de depósito tiene que ser positivo");
            }
            if(Balance - amount < 0)
            {
                throw new InvalidOperationException("No suficientes fondos en la cuenta");
            }

            var deposit = new Transaction(-amount, date, note);
            allTransactions.Add(deposit);
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
    }
}
