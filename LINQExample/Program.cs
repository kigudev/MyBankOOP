using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExample
{
    class Program
    {
        private static List<Student> students = new List<Student>
        {
            new Student {FirstName="Svetlana", LastName="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
            new Student {FirstName="Claire", LastName="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
            new Student {FirstName="Sven", LastName="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
            new Student {FirstName="Cesar", LastName="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
            new Student {FirstName="Debra", LastName="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
            new Student {FirstName="Fadi", LastName="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
            new Student {FirstName="Hanying", LastName="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
            new Student {FirstName="Hugo", LastName="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
            new Student {FirstName="Lance", LastName="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
            new Student {FirstName="Terry", LastName="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
            new Student {FirstName="Eugene", LastName="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
            new Student {FirstName="Michael", LastName="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
        };

        // LINQ to Objects
        static void Main(string[] args)
        {
            //int[] scores = { 97, 81, 92, 63 };

            //IEnumerable<int> scoreQuery =
            //    from score in scores
            //    where score > 80
            //    select score;

            IEnumerable<Student> studentQuery =
                from student in students
                where student.Scores[0] > 90 && student.Scores[3] < 80
                orderby student.Scores[0] descending
                select student;

            IEnumerable<Student> studentLambda =
                students
                .Where(c => c.Scores[0] > 90 && c.Scores[3] < 80)
                .OrderByDescending(c => c.Scores[0]);

            //foreach (var student in studentLambda)
            //{
            //    Console.WriteLine($"{student.LastName} {student.FirstName} {student.Scores[0]}");
            //}

            var studentQuery2 =
               from student in students
               group student by student.LastName[0]
               into studentGroup
               orderby studentGroup.Key
               select studentGroup;

            var studentLambda2 = students
                .GroupBy(student => student.LastName[0])
                .OrderBy(group => group.Key);

            foreach (var studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (var student in studentGroup)
                {
                    Console.WriteLine($"{student.LastName} {student.FirstName}");
                }
            }

            foreach (var studentGroup in studentLambda2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (var student in studentGroup)
                {
                    Console.WriteLine($"{student.LastName} {student.FirstName}");
                }
            }

            var studentQuery3 =
                from student in students
                let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                where totalScore / 4 < student.Scores[0]
                select $"{student.LastName} {student.FirstName}";

            var studentLambda3 = students
                .Where(student => student.Scores.Sum() / 4 < student.Scores[0])
                .Select(student => $"{student.LastName} {student.FirstName}");

            foreach (var item in studentLambda3)
            {
                Console.WriteLine(item);
            }


            var studentQuery4 =
                from student in students
                let totalScore = student.Scores.Sum()
                select totalScore;
            var averageScore = studentQuery4.Average();

            var averageScoreLambda = students.Average(student => student.Scores.Sum());

            Console.WriteLine("El promedio de la clase es: " + averageScoreLambda);


            // También se pueden utilizar métodos propios dentro de las consultas linq
            // En ciertos casos podemos quitar el Where si nuestro siguiente método de extensión permite recibir una expresión lambda
            var studentCount = students.Count(c => MiMetodo(c.ID.ToString()).StartsWith("1"));


            var lastName = "Garcia";
            var studentQuery5 =
                from student in students
                where student.LastName.Equals(lastName, StringComparison.CurrentCultureIgnoreCase)
                select student.FirstName;

            var studentLambda5 = students
                .Where(student => student.LastName.Equals(lastName, StringComparison.CurrentCultureIgnoreCase))
                .Select(c => c.FirstName);

            //onsole.WriteLine("Todos los garcias de la clase son:");
            //Console.WriteLine(string.Join(", ", studentQuery5));

            var studentQuery6 =
              from student in students
              let totalScore = student.Scores.Sum()
              where totalScore > averageScore
              select new { Id = student.ID, Score = totalScore };

            var studentLambda6 = students
                .Where(student => student.Scores.Sum() > averageScore)
                .Select(student => new {
                    Id = student.ID,
                    Score = student.Scores.Sum()
                });

            foreach (var item in studentLambda6)
            {
                Console.WriteLine($"Student id: {item.Id} Score: {item.Score}");
            }

        }

        public static string MiMetodo(string x)
        {
            return x;
        }
    }
}
