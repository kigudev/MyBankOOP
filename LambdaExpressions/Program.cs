using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Func y Action son delegados que encapsulan métodos en una expresión.

            // Func recibe y regresa valores.
            Func<int, int> square = x => x * x;

            // Action solo recibe valores.
            Action<int> action = x => Console.WriteLine(x);

            Console.WriteLine(square(5));
            action(3);

            int[] numbers = { 2, 3, 4, 5 };
            var squaredNumbers = numbers.Select(x => x * x);
            // Cada método que regrese un ienumerable se considera un método de extensión
            // (expresiones dentro de los métodos sin sentido alguno, solo es demostrativo)
            var squaredNumbers2 = numbers.Select(x => x * x).OrderBy(num => num).ThenBy(num => num).Select(num => num).Where(num => num == 0);
            squaredNumbers = numbers.Select(square);
            Console.WriteLine(string.Join(" ", squaredNumbers));


            Func<string, string> greet = name =>
            {
                string greeting = $"Hola {name}";
                string greeting2 = $"Hola y {greeting}";
                return greeting2;
            };

            Console.WriteLine(greet("Ivan"));

            // Se puede tener acciones sin parámetros
            Action line = () => Console.WriteLine();

            // Funcs con múltiples parámetros tiene que ser encerrados con paréntesis.
            Func<int, bool, int, int, int> multipleSquare = (x, y, z, w) => x * z * w;

            // En ocasiones el compilador no podrá saber que tipo de dato es el parametro que se está recibiendo, para ese caso hay que definirlo en el
            // mismo.
            Func<int, string, bool> isTooLong = (int x, string y) => y.Length > x;

            // Uso de 2 tuplas en un Func
            Func<(int, bool, int), (int, int)> multipleSquare2 = tupla => (tupla.Item1 * tupla.Item3, 100);
            // Uso de 1 tupla como salida en un Func
            Func<int, bool, int, (int, int)> multipleSquare3 = (MiNumero, MiBool, Multiplicador) => (MiNumero * Multiplicador, 100);

            // Desde C# 7.0 se pueden regresar tuplas
            var tuplas = MisTuplas();

            var mensajeBool = tuplas.EsCorrecto ? "correcta" : "incorrecta";
            // esto es lo mismo que una operación ternaria ^
            var mensajeBool2 = string.Empty;
            if (tuplas.EsCorrecto)
                mensajeBool2 = "correcta";
            else
                mensajeBool2 = "incorrecta";
            
            Console.WriteLine($"{tuplas.Mensaje} porque la operación fue {mensajeBool}");
            var miFecha = DateTime.Now.ToString("dd/mm/aaaa");

            // Uso de Func con parametros descartados (A partir de C# 9.0)           
            Func<int, int, int> constant = (_, _) => 42;
            Action<int, int> constants2 = (_, _) => Console.WriteLine(43);

            // un Action con método asincrono
            Action<int> miAccionAsincrona = async miParametro => await MiMetodoAsincrono();

            // un Action con serie de declaraciones
            Action<int> miAccionAsincrona2 = miParametro => { 
                Task.Delay(1000);
            };

            numbers.OrderBy(num => num);

            // métodos de extensión incluidas en la librería de linq
            var count = numbers.Count();
            
            // Métodos de extensión creadas por nosotros
            numbers.MiCount();

            var frase = "Mi clase de programación?";
            var cantidad = frase.WordCount();

            Console.WriteLine($"{frase} contiene {cantidad} palabras");

            var numberList = new List<int> { 2, 3, 4, 5 };
            numberList = numberList.Where(c => c == 2).ToList();




        }

      
        // método con cuerpo de expresión
        static string MiMetodo() => "x";


        // Demostración de tupla
        static (bool EsCorrecto, string Mensaje) MisTuplas()
        {
            var esCorrecto = true;
            var mensaje = "Mi mensaje";
            return (esCorrecto, mensaje);
        }

        static async Task MiMetodoAsincrono()
        {
            await Task.Delay(500);
            Console.WriteLine("esperando...");

           await Task.Delay(1000);
        }
    }
}
