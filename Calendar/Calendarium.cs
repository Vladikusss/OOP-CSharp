/*
 * Created by Vladdy | 17.02.2025
 * Last Updated: 21.02.2025
 * Program: Calendar - outputs the day of the week and the event on that date without using external libraries
 * Version: 1.0
 * Status: In Progress
 */

using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Calendar;

internal class Event
{
    // Approach 1 -> Make an API to figure out any events on the date /// fast and always up-to-date 
    // Approach 2 -> Download data, store in file, access from a file /// takes storage, resources.
}

internal class SpecialCode
{
    // Secret code - to output the day and the week to the user. 
    private static readonly string _code = "52-26-41-63-75-27";
    public static string Code => _code;
    public static List<string> AllMonths = new List<string>() {"january", "february", "march", "april", "may", "june",
        "july", "august", "september", "october", "november", "december"};
    public static List<string> WeekDays = new List<string>() {"monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday"};

    private static readonly Dictionary<string, int> MonthsDate = new Dictionary<string, int>()
    {
        { "january", 31 },
        { "february", 28 }, // 2025 is not a leap year, so February has 28 days
        { "march", 31 },
        { "april", 30 },
        { "may", 31 },
        { "june", 30 },
        { "july", 31 },
        { "august", 31 },
        { "september", 30 },
        { "october", 31 },
        { "november", 30 },
        { "december", 31 }
    };
    private static readonly Dictionary<string, int> MonthCode = new Dictionary<string, int>()
    {
        { "january", 5 },
        { "february", 2 },
        { "march", 2 },
        { "april", 6 },
        { "may", 4 },
        { "june", 1 },
        { "july", 6 },
        { "august", 3 },
        { "september", 7 },
        { "october", 5 },
        { "november", 2 },
        { "december", 7 }
    };

    public static bool ValidateMonth(string month)
    {
        bool monthExists = AllMonths.Contains(month) ? true : false;
        return monthExists;
    }
    public static bool ValidateDate(string month, int day)
    {
        bool dateExists;
        
        if (day >= 1 && day <= MonthsDate[month])
        {
            dateExists = true;
        }
        else
        {
            dateExists = false;
        }

        return dateExists;
    }

    public static void DayOfTheWeek(string month, int day)
    {
        // Date difference between 2 days:
        int DateDifference = Math.Abs(day - MonthCode[month]); 
        // Week difference between 2 days:
        int NumberOfWeeks = DateDifference / 7;
        // Number of days that don't form a week:
        int DaysLeft = DateDifference % 7;

        Console.WriteLine($"\nThe first sunday of {month} is on {MonthCode[month]}.\n" +
                          $"The information you entered: {month} / {day}\n" +
                          $"The date difference is {DateDifference}\n" +
                          $"This is {NumberOfWeeks} weeks and {DaysLeft} days in total\n" +
                          $"{day} of {month} falls on {WeekDays[DaysLeft]}\n");
    }
    
}


class Program
{
    static void Main()
    {
        string username; // User-defined nickname
        string month; // Month user is interested in
        string day; // String - Date user is interested in 
        int dayInt; // Integer - Date user is interested in 
        bool ValidatedMonth; // Validation for month
        bool ValidatedDate; // Validation for date
        

        Console.WriteLine("Hi. How can I call you?");
        username = Console.ReadLine();
        Console.WriteLine($"\nWelcome to the Calendarium, {username}!\n" +
                          $"\tThis program tells you:\n" +
                          $"* Any special events on the day you choose\n" +
                          $"* The date and week of the day you choose\n");
        
        while (true)
        {
            Console.WriteLine("What date are you interested in? Please enter a month (e.g. april): ");
            month = Console.ReadLine().ToLower();

            Console.WriteLine(SpecialCode.ValidateMonth(month));
            ValidatedMonth = SpecialCode.ValidateMonth(month);
            if (ValidatedMonth == false)
            {
                Console.WriteLine("\n[Error 1] --- Please only enter a valid month.\n");
                continue;
            }

            Console.WriteLine("What date are you interested in? Please enter day number (e.g. 3, 18, 29): ");
            day = Console.ReadLine();

            if (int.TryParse(day, out dayInt))
            {
                bool ValidatedDay = SpecialCode.ValidateDate(month, dayInt);
                Console.WriteLine(ValidatedDay);
            }
            else
            {
                Console.WriteLine("\n[Error 2] --- Please only enter a valid day.\n");
                continue;
            }
            
            SpecialCode.DayOfTheWeek(month, dayInt);
        }
    }
}
