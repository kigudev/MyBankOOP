using System;
using System.Linq;

namespace LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5));

            int[] numbers = { 2, 3, 4, 5 };
            var squaredNumbers = numbers.Select(x => x * x);
            numbers.Select(square);
            Console.WriteLine(string.Join(" ", squaredNumbers));


            Func<string, string> greet = name => {
                string greeting = $"Hola {name}";
                return greeting;
            };

            Console.WriteLine(greet("Ivan"));
        }

        static string MiMetodo() => "x";
    }
}
