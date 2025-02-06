using System;
using System.Collections.Generic;

namespace ConsoleApp3
{ // Program to generate and manipulate random numbers
    class Another
    {
        static void Main()
        {
            // Generating and Printing integers:
            List<int> randomIntegers = GenerateRandomIntegers();
            PrintRandomIntegers(randomIntegers);
            
            // Calculating and printing total of integers:
            int sumOfIntegers = ComputeSum(randomIntegers);
            Console.WriteLine($"The sum of random integers in the list is: {sumOfIntegers}");
            
            // Generating and Displaying histogram from integers:
            Dictionary<int, int> histogram = ComputeHistogram(randomIntegers);
            DisplayHistogram(histogram);
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
        

        static Dictionary<int, int> ComputeHistogram(List<int> nums)
        { // Function to compute frequency of each number
            Dictionary<int, int> frequency = new Dictionary<int, int>();
            // Dictionary data type from System.Collections.Generic

            foreach (int number in nums) // Loop through each number
            {
                if (frequency.ContainsKey(number))
                { // Check if number is in dictionary
                    frequency[number] += 1; // Increment frequency of number by 1
                }
                else
                { // If number is not in dictionary -> add it
                    frequency.Add(number, 1);
                }
            }

            return frequency;
        }


        static void DisplayHistogram(Dictionary<int, int> freq)
        { // Function to display histogram
            foreach (KeyValuePair<int, int> kvp in freq)
            { // Loop through each keyValuePair (kvp)
                Console.WriteLine($"{kvp.Key} : {kvp.Value}");
            }
        }
    }
}