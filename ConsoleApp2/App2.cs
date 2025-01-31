using System;

namespace ConsoleApp2
{
    class Practice
    {
        static void Main()
        {
            // Program to calculate compound interest:

            decimal amount;
            Console.WriteLine("Please enter the sum you want to put in: ");
            amount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine($"The sum you entered is {amount}");

            decimal interestRate = 4.11m;
            decimal percentageMultiplier = interestRate / 100m;
            Console.WriteLine($"The interest rate at the moment is {interestRate}");
            Console.WriteLine($"The percentage multiplier is {percentageMultiplier}");
            
            // Without withdrawals/deposits:
            decimal yearlyIncome = Math.Round(amount + (amount * percentageMultiplier), 2);
            decimal monthlyIncome = Math.Round((amount / 12) * percentageMultiplier, 2);
            decimal dailyIncome = Math.Round((amount / 365) * percentageMultiplier, 2);
            
            Console.WriteLine($"In one year your savings will be {yearlyIncome}");
            Console.WriteLine($"This is {monthlyIncome} monthly and {dailyIncome} daily.");
            
            
            // Practice irrelevant to main program:
            
            // Number of pizza shops
            int pizzaShops = 4332;

            // Number of employees
            int totalEmployees = 86928;

            // Revenue
            decimal revenue = 390819.28m;

            // Log the values to the console:
            Console.WriteLine(pizzaShops);
            Console.WriteLine(totalEmployees);
            Console.WriteLine(revenue);
            
            
            
            // Your Age
            int userAge = 20;

            // Length of years on Jupiter (in Earth years)
            double jupiterYears = 11.86d;

            // Age on Jupiter
            double jupiterAge = userAge / jupiterYears;

            // Time to Jupiter
            double journeyToJupiter = 6.142466d;

            // New Age on Earth
            double newEarthAge = userAge + journeyToJupiter;

            // New Age on Jupiter
            double newJupiterAge = newEarthAge / jupiterYears;

            // Log calculations to console
            Console.WriteLine(userAge);
            Console.WriteLine(jupiterAge); // before
            Console.WriteLine(newEarthAge); // after
            Console.WriteLine(newJupiterAge);
            
            
            // Starting variables 
            int numberOne = 12932;
            int numberTwo = -2828472;

            // Use built-in methods and save to variable 
            double numberOneSqrt = Math.Floor(Math.Sqrt(numberOne));

            // Use built-in methods and save to variable 
            double numberTwoSqrt = Math.Floor(Math.Sqrt(Math.Abs(numberTwo)));

            // Print the lowest number
            Console.WriteLine(Math.Min(numberOneSqrt, numberTwoSqrt));
        }
    }
}

