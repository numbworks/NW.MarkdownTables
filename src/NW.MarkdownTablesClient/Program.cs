using System;
using System.Collections.Generic; 
using NW.MarkdownTables;
using NW.MarkdownTables.Strategies;

namespace NW.MarkdownTablesClient
{
    class Program
    {
        static void Main(string[] args)
        {

            Run(() => RunExample1(), nameof(RunExample1));
            Run(() => RunExample2(), nameof(RunExample2));

            Console.ReadKey();

        }
        public static void Run(Action action, string actionName)
        {

            Console.WriteLine(new string('=', 60));
            Console.WriteLine(actionName);
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(Environment.NewLine);

            action.Invoke();

            Console.WriteLine(Environment.NewLine);

        }
        public static void RunExample1()
        {

            Car car = new Car()
                {
                    Brand = "Dodge",
                    Model = "Charger",
                    Year = 1966,
                    Price = 13500,
                    Currency = "USD"
                };

            IMarkdownTabulizer markdownTabulizer = new MarkdownTabulizer();
            string markdownTable = markdownTabulizer.ToMarkdownTable(false, car);

            Console.WriteLine(markdownTable);

        }
        public static void RunExample2()
        {

            List<Car> cars = new List<Car>()
            {

                new Car()
                {
                    Brand = "Dodge",
                    Model = "Charger",
                    Year = 1966,
                    Price = 13500,
                    Currency = "USD"
                },
                new Car()
                {
                    Brand = "Hummer",
                    Model = "H2",
                    Year = 2001,
                    Price = 24200,
                    Currency = "USD"
                }

            };

            IMarkdownTabulizer markdownTabulizer = new MarkdownTabulizer();
            string markdownTable
                = markdownTabulizer.ToMarkdownTable(
                    false,
                    NullHandlingStrategies.ThrowException,
                    cars);

            Console.WriteLine(markdownTable);

        }

    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public uint Year { get; set; }
        public uint Price { get; set; }
        public string Currency { get; set; }
    }

}

/*
    Author: numbworks@gmail.com
    Last Update: 11.10.2021
*/