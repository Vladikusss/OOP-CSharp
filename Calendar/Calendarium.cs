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
        { "January", 5 },
        { "February", 2 },
        { "March", 2 },
        { "April", 6 },
        { "May", 4 },
        { "June", 1 },
        { "July", 6 },
        { "August", 3 },
        { "September", 7 },
        { "October", 5 },
        { "November", 2 },
        { "December", 7 }
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
}


class Program
{
    static void Main()
    {
        string username;

        Console.WriteLine("Hi. How can I call you?");
        username = Console.ReadLine();
        Console.WriteLine($"\nWelcome to the Calendarium, {username}!\n" +
                          $"\tThis program tells you:\n" +
                          $"* Any special events on the day you choose\n" +
                          $"* The date and week of the day you choose\n");

        bool correctData = true;
        while (correctData)
        {
            Console.WriteLine("What date are you interested in? Please enter a month (e.g. april): ");
            string month = Console.ReadLine().ToLower();

            Console.WriteLine(SpecialCode.ValidateMonth(month));
            bool ValidatedMonth = SpecialCode.ValidateMonth(month);

            Console.WriteLine("What date are you interested in? Please enter day number (e.g. 3, 18, 29): ");
            int day = Convert.ToInt16(Console.ReadLine().ToLower());
            
            bool ValidateDay = SpecialCode.ValidateDate(month, day);
            Console.WriteLine(ValidateDay);
        }
    }
}
