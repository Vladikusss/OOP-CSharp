using System;
using System.Collections.Generic;


namespace ConsoleApp4
{
    class Student
    {
        private string _name;
        private string _surname;
        private string _module;
        private int _grade;
        public static int NumberOfStudents = 0;


        public string Name
        {
            get { return _name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Name is required");
                }
                else
                {
                    _name = value;
                }
            }
        }

        public int Grade
        {
            get { return _grade; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _grade = value;
                }
            }
        }

        /* Declaration above is traditional get method.
         From c# version 6.0 (2015) the new method was introduced:
         public string FullName => Name + " " + Surname;

         get {} is preferred when validation is needed before assigning a value - i.e. chains of logic.
         => expression-bodied for simple expressions to make code more readable.
        */

        public Student(string studentName, string studentSurname, string studentModule, int studentGrade)
        {
            Name = studentName;
            Surname = studentSurname;
            FullName = $"{studentName} {studentSurname}";
            Module = studentModule;
            Grade = studentGrade;
            NumberOfStudents++;
        }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student(
                "John",
                "Doe",
                "Object-Oriented Programming",
                73);
            
            Console.WriteLine($"{student1.FullName}, welcome to the module {student1.Module}!\n" +
                              $"Your current grade is {student1.Grade}. Let's see if you can improve it!");
            Console.WriteLine($"{student1.FullName}, do you want to improve your grade? y/n");
            string userInput = Console.ReadLine().ToLower();
            if (userInput == "y")
            {
                Console.WriteLine($"You can improve your grade by doing the following:\n" +
                                  $"1. Focus on Understanding Code Design and Architecture.\n" +
                                  $"2. Master Core OOP Concepts.\n" +
                                  $"3. Practice Coding Regularly.\n");
            }
            else if (userInput == "n")
            {
                Console.WriteLine($"How come you don't want to improve your grade?");
                Console.ReadLine();
                Console.WriteLine($"Okay. I understand you, {student1.Name}.\n" +
                                  $"At the end of the day success is all that matters.");
            }
            else
            {
                Console.WriteLine("Please enter a valid input next time!");
            }
            
        }
        
    }
}