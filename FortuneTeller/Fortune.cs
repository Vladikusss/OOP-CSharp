/*
 * Created by Vladdy | 16.02.2025
 * Last Updated: 16.02.2025
 * Program: Simple fortune-teller
 * Version: 1.0
 * 
 * Part of this code is taken and belongs to Microsoft:
 * https://learn.microsoft.com/en-us/collections/yz26f8y64n7k07
 */
using System;

namespace FortuneTeller;

internal class Fortune
{ // Main Functionality of the program. 
    private static Random _randInt = new Random(); // Instance of a random class
    public static Random randInt => _randInt;
    internal static void TellFortune()
    {
        int luck = randInt.Next(100); // Random integer between 0-99

        // Strings of fortune texts:
        string[] text = {"You have much to", "Today is a day to", "Whatever work you do", "This is an ideal time to"};
        string[] good = {"look forward to.", "try new things!", "is likely to succeed.", "accomplish your dreams!"};
        string[] bad = {"fear.", "avoid major decisions.", "may have unexpected outcomes.", "re-evaluate your life."};
        string[] neutral = {"appreciate.", "enjoy time with friends.", "should align with your values.", "get in tune with nature."};

        Console.WriteLine("A fortune teller whispers the following words:");
        // Simplified else-if statement
        string[] fortune = (luck > 75 ? good : (luck < 25 ? bad : neutral));
        for (int i = 0; i < 4; i++) 
        { // Loop through and print texts of fortune
            Console.Write($"{text[i]} {fortune[i]} ");
        }
    }
    
}

internal class Program
{ // Main class of the program 
    static void Main()
    {
        string username;
        
        Console.WriteLine("Hi. How can I call you?");
        username = Console.ReadLine();
        Console.WriteLine($"{username}, would you like to know your fortune for today? y/n");

        // Prompt user to make an input
        bool play = true;
        while (play)
        {
            string userInput = Console.ReadLine().ToLower();
            if (userInput == "y")
            { // Call the method from another class to know your fortune
                Fortune.TellFortune();
                play = false;
            }
            else if (userInput == "n")
            {
                Console.WriteLine("Okay... I am terminating myself :( ");
                play = false;
                // Environment.Exit(0); // Alternative -> Successful exit from the program
            }
            else
            {
                Console.WriteLine("Sorry, I didn't understand you. Please try again.\n");
            }
        }
        
    }
}