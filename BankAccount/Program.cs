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
        }


    }
}