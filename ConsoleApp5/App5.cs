using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 1.5 * 20; i++)
            { // O(n) - execution time grows in direct proportion to input (linear growth)
                Console.Write($"{i}, ");
            }
            Console.WriteLine();
            for (int i = 20; i >= 1; i--)
            { // O(n) - execution time grows in direct proportion to input (linear growth)
                Console.Write($"{i}, ");
            }
        }
}
}
