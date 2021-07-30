using LINQExample;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExcercises
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            // Which of the following numbers are multiples of 4 or 6
            List<int> mixedNumbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            // Output how many numbers are in this list
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            // Given the same customer set, display how many millionaires per bank.
            List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            // Get the customers that their balance is more than 1000000

            // Order the customers by their balance
            // Make a sum of wealth for each bank
            // Get the first name of the customers that their balance is less than 100000 and their bank has only 3 characters
            var customerWealthQuery =
                from customer in customers
                group customer by customer.Bank into bank
                select new { Bank = bank.Key, Wealth = (from b in bank select b.Balance).Sum() };
            //select new { Bank = bank.Key, Wealth = bank.Sum(customer => customer.Balance) };

            foreach (var item in customerWealthQuery)
            {
                Console.WriteLine($"bank: {item.Bank} wealth: {item.Wealth}");
            }

            // B.1 Find the string which starts and ends with a specific character : AM
            // B.2 Write a program in C# Sharp to display the list of items in the array according to the length of the string then by name in ascending order.
            // B.3 Write a program in C# Sharp to split a collection of strings into 3 random groups.
            string[] cities =
            {
                "ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS"
            };

            // C.1 Write a program in C# Sharp to display the number and frequency of number from given array.
            // C.2 Write a program in C# Sharp to display a list of unrepeated numbers.
            // C.3 Write a program in C# Sharp to display numbers, multiplication of number with frequency and the frequency of number of giving array.
            int[] arr1 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };

            // D.1 Get the top student of the list making an average of their scores.
            // D.2 Get the student with the lowest average score.
            // D.3 Get the last name of the student that has the ID 117
            List<Student> students = new List<Student>
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
        }

        public void DemostracionDeFiltradoDeListaDeLista(List<Student> students)
        {
            var myStudents = students.Select(student =>
            {
                // modificar el punta del estudiante antes de regresarlo a la lista
                student.Scores = student.Scores.Select(score =>
                {
                    // para cada calificación si la calificación es igual a 92, modificarla a 100
                    if (score == 92)
                        score = 100;
                    return score;
                }).ToList();
                return student;
            });

            var scores = students.SelectMany(c => c.Scores).Select(score =>
            {
                // para cada calificación si la calificación es igual a 92, modificarla a 100
                if (score == 92)
                    score = 100;
                return score;
            }
            );

            foreach (var student in myStudents)
            {
                Console.WriteLine($"{student.FirstName} scores: {string.Join(", ", student.Scores)}");
            }
        }
    }

    internal class Customer
    {
        public string Name { get; internal set; }
        public double Balance { get; internal set; }
        public string Bank { get; internal set; }
    }
}