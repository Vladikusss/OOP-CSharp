using System;
using System.Collections.Generic;

namespace ConsoleApp3
{ // Program to generate random numbers
    class Another
    {
        static void Main()
        {
            GenerateRandomIntegers();
        }

        static void GenerateRandomIntegers()
        {
            Console.WriteLine("Started");
            List<int> numbers = new List<int>(); // List data type from System.Collections.Generic
            
            Random random = new Random(); // An Instance of a class Random

            for (int i = 0; i < 100; i++)
            { // Generates 100 random numbers
                numbers.Add(random.Next(1, 1001));
            }

            for (int x = 0; x < numbers.Count; x++)
            { // Output generated numbers to the console
                Console.Write(numbers[x] + ", ");
                if ((x + 1) % 10 == 0)
                { // Every 10 numbers, a new line is added
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Ended");
        }
    }
}