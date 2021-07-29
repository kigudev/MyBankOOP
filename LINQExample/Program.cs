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

            //foreach (var student in studentQuery)
            //{
            //    Console.WriteLine($"{student.LastName} {student.FirstName} {student.Scores[0]}");
            //}

            var studentQuery2 =
               from student in students
               group student by student.LastName[0]
               into studentGroup
               orderby studentGroup.Key
               select studentGroup;

            //foreach (var studentGroup in studentQuery2)
            //{
            //    Console.WriteLine(studentGroup.Key);
            //    foreach (var student in studentGroup)
            //    {
            //        Console.WriteLine($"{student.LastName} {student.FirstName}");
            //    }
            //}

            var studentQuery3 =
                from student in students
                let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                where totalScore / 4 < student.Scores[0]
                select $"{student.LastName} {student.FirstName}";

            //foreach (var item in studentQuery3)
            //{
            //    Console.WriteLine(item);
            //}


            var studentQuery4 =
                from student in students
                let totalScore = student.Scores.Sum()
                select totalScore;

            var averageScore = studentQuery4.Average();
            Console.WriteLine("El promedio de la clase es: " + averageScore);

            var lastName = "Garcia";
            var studentQuery5 =
                from student in students
                //where student.LastName.Equals("garcia", StringComparison.CurrentCultureIgnoreCase)
                where student.LastName == lastName.ToLower()
                select student.FirstName;

            //Console.WriteLine("Todos los garcias de la clase son:");
            //Console.WriteLine(string.Join(", ", studentQuery5));

            var studentQuery6 =
              from student in students
              let totalScore = student.Scores.Sum()
              where totalScore > averageScore
              select new{ Id = student.ID, Score = totalScore};

            foreach (var item in studentQuery6)
            {
                Console.WriteLine($"Student id: {item.Id} Score: {item.Score}");
            }
        }


    }
}
