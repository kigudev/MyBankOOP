using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingConventions
{
    // Clases, records y estructuras se usa el formato Pascal (primera letra en mayuscula).
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var address = new PhysicalAddress("street", "city", "state", "123");
            var state = address.State;

            var worker = new Worker();

        }
    }

    /// <summary>
    /// Esta es mi clase servicio data
    /// </summary>
    public class DataService { }

    public record PhysicalAddress(string Street,string City,string State,string ZipCode);

    public interface IWorker
    {

    }

    // Campos y métodos públicos en formato Pascal.
    /// <summary>
    /// 
    /// </summary>
    public class Worker : IWorker
    {
        public bool IsValid;
        private IWorker _workerAux;

        public IWorker WorkerAux { get; set; }

        public void MyMethod() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public void MyMethodParams(int param1, int param2, int param3) {
            var param4 = 0;

            if (
                param1 > param2 && 
                param1 > param3 && 
                param1 > param3 && 
                param1 > param3 && 
                param1 > param3
                ) 
            {
                Console.WriteLine($"comentario {param2} 2do comentario.");
            }


            var var1 = "Esto sabemos que es un string";
            var var2 = 27;

            long var3 = Convert.ToInt64(Console.ReadLine());
            //List<int> var4 = ClaseEjemplo.MiResultado();

            //foreach(int x in var4)
            //{
            //    _ = 200;
            //}


            var vocales = new string[]{ "a", "e", "i", "o", "u"};
            string[] vocales2 = { "a", "e", "i", "o", "u"};
            var vocales3 = new List<string>{"a", "b" };

            try
            {

            }
            catch (Exception)
            {

            }
            finally
            {

            }

            var instancia1 = new DataService();
            DataService instance2 = new();
            DataService instance3 = new DataService();
        }
    }

}
