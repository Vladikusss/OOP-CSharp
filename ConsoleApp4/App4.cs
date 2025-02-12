using System;
using System.Collections.Generic;


namespace ConsoleApp4
{
    class Student
    {
        public string Name;
        public string Surname;
        public string Module;
        public int Grade;
        public static int NumberOfStudents = 0;

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
        }
        
    }
}