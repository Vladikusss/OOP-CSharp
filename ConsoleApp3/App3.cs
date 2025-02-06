using System;
using System.Collections.Generic;

namespace ConsoleApp3
{ // Program to generate and manipulate random numbers
    class Another
    {
        static void Main()
        {
            List<int> randomIntegers = GenerateRandomIntegers();
            PrintRandomIntegers(randomIntegers);
            int sumOfIntegers = ComputeSum(randomIntegers);
            Console.WriteLine($"The sum of random integers in the list is: {sumOfIntegers}");
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
        

        static void PrintRandomIntegers(List<int> nums)
            { // Function to print random numbers
                for (int x = 0; x < nums.Count; x++)
                { // Output generated numbers to the console
                    Console.Write(nums[x] + ", ");
                    if ((x + 1) % 10 == 0)
                    { // Every 10 numbers a new line is added
                        Console.WriteLine();
                    }
                }
            }

        static int ComputeSum(List<int> nums)
        { // Function to calculate sum of random integers
            int total = 0;
            foreach (int number in nums)
            { // Iterate through each number in list
                total += number;
            }

            return total; // Return the sum
        }
            
    }
}