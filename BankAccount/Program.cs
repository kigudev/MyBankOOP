using System;

namespace MyBank
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var account = new BankAccount("Rene", 1000);
            Console.WriteLine($"la cuenta con número {account.Number} de {account.Owner} fue creada con {account.Balance} pesos");

            try
            {
                account.MakeWithdrawal(200, DateTime.Now, "Para los tacos");
                Console.WriteLine($"Nuevo balance: {account.Balance}");

                account.MakeDeposit(100, DateTime.Now, "Regalo de amigo");
                Console.WriteLine($"Nuevo balance: {account.Balance}");

                account.MakeDeposit(-100, DateTime.Now, "Regalo de amigo 2");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Se intentó agregar una cantidad con negativos");
                Console.WriteLine(ex.Message);
            }catch(InvalidOperationException ex)
            {
                Console.WriteLine("Se intentó sacar más dinero de lo disponible");
                Console.WriteLine(ex.Message);
            }

            try
            {
                account.MakeWithdrawal(2000, DateTime.Now, "Para los tacos");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Se intentó sacar más dinero de lo disponible");
                Console.WriteLine(ex.Message);
            }

            account.MakeDeposit(500, DateTime.Now, "Regalo de amigo 3");
            Console.WriteLine($"Nuevo balance: {account.Balance}");

            Console.WriteLine(account.GetAccountHistory());


            // Cuenta de intereses
            var interesEarningAccount = new InterestEarningAccount("Mario", 2000);
            interesEarningAccount.MakeDeposit(100, DateTime.Now, "Para las sodas");
            interesEarningAccount.MakeDeposit(200, DateTime.Now, "Regalo de cumpleaños");
            interesEarningAccount.MakeWithdrawal(300, DateTime.Now, "Mandado");
            interesEarningAccount.PerformMonthEndTransactions();
            Console.WriteLine(interesEarningAccount.GetAccountHistory());

            // Cuenta de tarjeta de regalo
            var giftCardAccount = new GiftCardAccount("Rene", 100, 50);
            giftCardAccount.MakeWithdrawal(10, DateTime.Now, "Regalo");
            giftCardAccount.MakeWithdrawal(12, DateTime.Now, "Regalo 2");
            giftCardAccount.PerformMonthEndTransactions();
            Console.WriteLine(giftCardAccount.GetAccountHistory());

            // Cuenta de línea de crédito
            var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 2000);
            lineOfCredit.MakeWithdrawal(1000, DateTime.Now, "Salida al cine");
            lineOfCredit.MakeDeposit(100, DateTime.Now, "Pago de cine parcial");
            lineOfCredit.MakeWithdrawal(2000, DateTime.Now, "Restaurante");
            lineOfCredit.PerformMonthEndTransactions();
            Console.WriteLine(lineOfCredit.GetAccountHistory());
        }


    }
}