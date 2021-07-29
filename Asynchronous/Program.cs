using System;
using System.Threading.Tasks;

namespace Asynchronous
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("el café está listo");

            Task<Egg> eggsTask = FryEggsAsync(2);
            Egg eggs = await eggsTask;
            Console.WriteLine("los huevos están listos");

            Task<Bacon> baconTask = FryBaconAsync(3);
            Bacon bacons = await baconTask;
            Console.WriteLine("El tocino está listo");

            Task<Toast> toastTask = ToastBreadAsync(2);
            Toast toast = await toastTask;
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("El pan está listo");

            Juice oj = PourOJ();
            Console.WriteLine("El jugo está listo");

            Console.WriteLine("El desayuno está listo");

        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Sirviendo jugo de naranja");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) => Console.WriteLine("Se aplicó mermelada a pan");

        private static void ApplyButter(Toast toast) => Console.WriteLine("Se aplicó mantequilla a pan");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Poniendo una rebanada de pan en la tostadora");
            }
            Console.WriteLine("Tostando el pan...");
            await Task.Delay(3000);
            Console.WriteLine("Quitamos el pan de la tostadora");
            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"poniendo {slices} tiras de tocino en el sartén");
            Console.WriteLine("Cocinando el tocino de un lado");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Volteando tira de tocino...");
            }
            Console.WriteLine("Cocinando el tocino del otro lado");
            Task.Delay(3000).Wait();
            Console.WriteLine($"Poner tocino en plato");
            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Calentando el sarten...");
            await Task.Delay(3000);
            Console.WriteLine($"Quebrando los {howMany} huevos");
            Console.WriteLine($"Cocinando los huevos...");
            await Task.Delay(3000);
            Console.WriteLine($"Poner huevos en plato");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Sirviendo café");
            return new Coffee();
        }
    }
}
