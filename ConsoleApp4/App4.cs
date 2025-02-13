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
            get => _name;
            set => _name = string.IsNullOrEmpty(value) ? "unknown" : value;
        }

        public string Surname
        {
            get => _surname;
            set => _surname = string.IsNullOrWhiteSpace(value) ? "unknown" : value;
        }
        
        public string FullName => $"{Name} {Surname}";

        public string Module
        {
            get => _module;
            set => _module = String.IsNullOrWhiteSpace(value) ? "unknown" : value;
        }
        
        public int Grade
        {
            get => _grade;
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _grade = value;
                }
                else
                {
                    Console.WriteLine("Invalid grade value, defaulting to 0!");
                    _grade = 0;
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

        public void DisplayInfo()
        {
            Console.WriteLine($"Student Name: {FullName}");
            Console.WriteLine($"Module: {Module}");
            Console.WriteLine($"Grade: {Grade}");
            Console.WriteLine("--------------------------");
        }

        public void ComputeGradeCategory()
        {
            if (Grade >= 0 && Grade < 40)
            {
                Console.WriteLine($"You failed with a mark of {Grade}");
            }
            else if (Grade >= 40 && Grade < 60)
            {
                Console.WriteLine($"You passed with a mark of {Grade}");
            }
            else if (Grade >= 60 && Grade < 80)
            {
                Console.WriteLine($"You were graded merit with a mark of {Grade}");
            }
            else if (Grade >= 80 && Grade <= 100)
            {
                Console.WriteLine($"You were graded distinction with a mark of {Grade}");
            }
            else
            {
                Console.WriteLine($"No valid grade was given to {FullName} at {Module} class");
            }
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

            student1.DisplayInfo();
            student1.ComputeGradeCategory();
        }
        
    }
}