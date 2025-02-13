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
        public static int NumberOfStudents { get; private set; } = 0;
    


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

        public string Surname
        {
            get { return _surname; }
            set {
                if (String.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Surname is required");
                }
                else
                {
                    _surname = value;
                }
            }
        }
        
        public string FullName => $"{Name} {Surname}";

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

        public string Module
        {
            get { return _module; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Module is required");
                }
                else
                {
                    _module = value;
                }
            }
        }
        

        public Student(string studentName, string studentSurname, string studentModule, int studentGrade)
        {
            Name = studentName;
            Surname = studentSurname;
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