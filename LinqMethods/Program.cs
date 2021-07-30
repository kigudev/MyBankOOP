using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            // método que nos dice si dos listas son iguales
            var list1 = new List<int> { 1, 2, 3 };
            var list2 = new List<int> { 1, 2, 3 };
            var list3 = new List<int> { 4, 5, 6 };
            var list5 = new List<int> { 5, 5, 5 };

            bool res1 = list1.SequenceEqual(list2);
            bool res2 = list1.SequenceEqual(list3);

            Console.WriteLine($"res1 es {res1} - res2 es {res2}");

            // agrega de uno en uno a la lista1
            list1.Add(4);
            list1.Add(5);
            list1.Add(6);
            list1.Remove(4);
            Console.WriteLine(string.Join(", ", list1));

            // agrega a la lista1 la lista2
            list1.AddRange(list2);
            list1.AddRange(list2);
            Console.WriteLine(string.Join(", ", list1));

            // quita todos los elementos que sean repetidos
            list1 = list1.Distinct().ToList();
            Console.WriteLine(string.Join(", ", list1));

            // obtener el primer elemento
            var num1 = list1.First();
            Console.WriteLine(num1);

            var num2 = list1.First(c => c == 2);
            Console.WriteLine(num2);

            var num3 = list1.Last(c => c == 2);
            Console.WriteLine(num3);

            // concatenación de ordenamiento
            var list4 = list1.OrderBy(c => c).ThenByDescending(c => c);

            int num4 = list1.FirstOrDefault(c => c == 22);
            Console.WriteLine(num4);

            int num5 = list1.LastOrDefault(c => c == 22);
            Console.WriteLine(num4);

            // si la lista tiene elementos
            bool existe = list1.Any();
            Console.WriteLine("Hay elementos en la lista: " + existe);

            // si la lista tiene el 3
            bool existe3 = list1.Any(c => c == 10);
            Console.WriteLine("Existe el 3 en la lista: " + existe3);


            // si todos los elementos de la lista son iguales a 1
            bool existe4 = list1.All(c => c == 1);
            Console.WriteLine("Todos los elementos de la lista son iguales: " + existe4);

            // si todos los elementos de la lista son iguales a 1
            bool existe5 = list5.All(c => c == 5);
            Console.WriteLine("Todos los elementos de la lista son iguales: " + existe5);

            // se obtienen los primeros 2 elementos
            var num6 = list1.Take(2);
            var num7 = list1.TakeWhile(c => c == 1);
            Console.WriteLine(string.Join(", ", num6));
            Console.WriteLine(string.Join(", ", num7));

            // se brincan los primeros 2 elementos
            var num8 = list1.Skip(2);
            Console.WriteLine(string.Join(", ", num8));

            var num9 = list1.SkipWhile(c => c == 1);
            Console.WriteLine(string.Join(", ", num9));

            // va a quitar todas las coincidencias a 2
            list3.RemoveAll(c => c == 2);

            //
            list3.RemoveAt(3);

            // se va a insertar el 20 en la posición 3
            list3.Insert(3, 20);

        }
    }
}
