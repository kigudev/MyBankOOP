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

            Egg eggs = await FryEggs(2);
            Console.WriteLine("los huevos están listos");

            Bacon bacon = FryBacon(3);
            Console.WriteLine("El tocino está listo");

            Toast toast = ToastBread(2);
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

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Poniendo una rebanada de pan en la tostadora");
            }
            Console.WriteLine("Tostando el pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Quitamos el pan de la tostadora");
            return new Toast();
        }

        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"poniendo {slices} tiras de tocino en el sartén");
            Console.WriteLine("Cocinando el tocino de un lado");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Volteando tira de tocino...");
            }
            Console.WriteLine("Cocinando el tocino del otro lado");
            Task.Delay(3000).Wait();
            Console.WriteLine($"Poner tocino en plato");
            return new Bacon();
        }

        private static async Task<Egg> FryEggs(int howMany)
        {
            Console.WriteLine("Calentando el sarten...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"Quebrando los {howMany} huevos");
            Console.WriteLine($"Cocinando los huevos...");
            Task.Delay(3000).Wait();
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
