using System;
using System.Collections.Generic;

namespace ConsoleApp3
{ // Program to generate random numbers
    class Another
    {
        static void Main()
        {
            List<int> randomIntegers = GenerateRandomIntegers();
            printRandomIntegers(randomIntegers);
        }

        static List<int> GenerateRandomIntegers()
        { // Function to generate 100 numbers
            Console.WriteLine("Started");
            List<int> numbers = new List<int>(); // List data type from System.Collections.Generic

            Random random = new Random(); // An Instance of a class Random

            for (int i = 0; i < 100; i++)
            {
                // Generates 100 random numbers
                numbers.Add(random.Next(1, 1001));
            }

            return numbers;
        }
        

        static void printRandomIntegers(List<int> nums)
            { // Function to print random numbers
                for (int x = 0; x < nums.Count; x++)
                { // Output generated numbers to the console
                    Console.Write(nums[x] + ", ");
                    if ((x + 1) % 10 == 0)
                    { // Every 10 numbers, a new line is added
                        Console.WriteLine();
                    }
                }
            }
            
            
    }
}