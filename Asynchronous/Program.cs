using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asynchronous
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("el café está listo");

            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = MakeToastWithButterAndJamAsync(2);

            //await Task.WhenAll(eggsTask, baconTask, toastTask);
            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };

            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);

                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("los huevos están listos");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("El tocino está listo");
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine("El pan está listo");
                }
                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = PourOJ();
            Console.WriteLine("El jugo está listo");

            Console.WriteLine("El desayuno está listo");
        }

        private static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
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
            await Task.Delay(2000);
            //Console.WriteLine("Ay se nos está quemando el pan");
            //throw new InvalidOperationException("El pan está quemado");
            await Task.Delay(1000);
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
            await Task.Delay(3000);
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