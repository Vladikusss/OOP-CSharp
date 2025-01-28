using System;


namespace Program.cs
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("How old are you?");
            string input;
            input = Console.ReadLine();
            
            Console.WriteLine("What's your name?");
            string name = Console.ReadLine();
            Console.WriteLine($"Your name is {name}. You are {input} years old.");
            
            
            // Create Variables
            string name2;
            string breed;
            int age = 5;
            double weight = 65.22;
            bool spayed = true;

            name2 = "Shadow";
            breed = "Golden Retriever";

            // Print variables to the console
            Console.WriteLine($"{name2}");
            Console.WriteLine($"{breed}");
            Console.WriteLine($"{age}");
            Console.WriteLine($"{weight}");
            Console.WriteLine($"{spayed}");

            bool correct = true;
            bool wrong = false;

            string ageString = "25";
            int ageInt = Convert.ToInt16(ageString); // int 16 = short, 32 = int, 64 = long
            
            Console.WriteLine(Convert.ToString(wrong));


        }
    }
}
