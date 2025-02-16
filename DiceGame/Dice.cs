/*
 * Created by Vladdy | 14.02.2025
 * Simple dice game where user plays against the computer.
 * What is new?
 * In v1.03 I added more classes, properties, methods, and reconstructed the flow of the program.
 */

using System;
using System.Collections.Generic;

namespace DiceGame
{
    internal class Game
    {
        private string _title; // Private property inside the class
        public string Title => _title; // Read-only property -> private property needs changing for new value
        private static Random _rnd = new Random(); // Instance of the Random class
        public static Random Rnd => _rnd;

        public Game() // Class constructor
        {
            _title = "DiceGame v1.03"; // Title of the game 
        }

        public void StartGame() // Start function - output Metadata to user
        {
            Console.WriteLine($"{Title} successfully started.\n"); // Output to the user
        }

        public static int RollDice()
        {
            int roll = Rnd.Next(1, 7); // minVal is inclusive, maxVal is exclusive
            return roll; // Return the random number (1-6)
        }
    }

    internal class Dice {
        public int Roll()
        {
            return Game.RollDice();
        }
        public void PlayTurn()
        {
            int computerRoll = Roll();
            int userRoll = Roll();
            
            Console.WriteLine($"The computer rolls: {computerRoll}");
            Console.WriteLine($"The user rolls: {userRoll}\n");

            if (userRoll >= computerRoll)
            {
                Console.WriteLine("You win! +1 ^ to you!\n");
                Player.PlayerScore++;
            }
            else
            {
                Console.WriteLine("You lose! +1 ^ to computer!\n");
                Player.ComputerScore++;
            }
        }
    }
    
    internal class Player
    {
        private static Dice _dice = new Dice();
        public static Dice DiceRoll => _dice;
        public static int PlayerScore { get; set; }
        public static int ComputerScore { get; set; }
    }

    internal class Program
    {
        static void Main()
        {
            Game session = new Game(); // Instance of the Game class
            session.StartGame();
            
            string continuePlaying = "y";
            while (continuePlaying.ToLower() == "y")
            {
                Player.DiceRoll.PlayTurn();
                Console.WriteLine("Computer has a score of: " + Player.ComputerScore);
                Console.WriteLine("Player has a score of: " + Player.PlayerScore);

                Console.WriteLine("Do you want to play again? (y/n): ");
                continuePlaying = Console.ReadLine();
                Console.WriteLine();
            }
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(); // Await for user input before closing the console. 
        }
    }
    
}
