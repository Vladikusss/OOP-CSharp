using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            
            for (int i = 1; i <= 1.5 * n; i++)
            { // O(n) - execution time grows in direct proportion to input (linear growth)
                Console.Write($"{i}, ");
            }
            Console.WriteLine();
            
            for (int i = n; i >= 1; i--)
            { // O(n) - execution time grows in direct proportion to input (linear growth)  
                Console.Write($"{i}, ");
            }
            Console.WriteLine();

            for (int i = 2; i <= n; i++)
            { // O(n) - iterates and increments, hence linear
                for (int j = 0; j <= n; j += n / 4)
                { // O(1) - always runs exactly 5 times no matter how large n is
                    Console.WriteLine($"{i}, {j}");
                }
            } // O(n) * O(1) = O(n)
            
            
        }
}
}
