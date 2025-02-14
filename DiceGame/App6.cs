using System;
using System.Collections.Generic;

namespace DiceGame
{
    internal class Game
    {
        private string _title; // Private property inside the class
        public string Title => _title; // Read-only property -> private property needs changing for new value

        public Game() // Class constructor
        {
            _title = "DiceGame v1.01"; // Title of the game 
        }

        public void StartGame()
        {
            Console.WriteLine($"{Title} successfully started."); // Output to the user
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Game Session = new Game(); // Instance of the Game class
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(); // Await for user input before closing the console. 
        }
    }
    
}
