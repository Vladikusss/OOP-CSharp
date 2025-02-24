/*
 * Created by Vladdy | 23.02.2025
 * Last Updated: 24.02.2025
 * Program: API Testing in c#
 * Version: 3.0
 * Status: Completed.
 * Can Be Improved: Yes
 */

using System;
using System.Net.Http; // Used to make http calls
using System.Threading.Tasks; // Used for asynchronous operations
using System.Text.Json; // Used to parse json data
using System.Collections.Generic; // Used to make lists 
using System.Globalization; // Used to validate user input
using System.Linq; // Used to filter and extract data

namespace Calendar
{
    internal class TestProgram
    {
        public static List<string> countryCode = new List<string>() { "GB", "DE", "JP", "LV", "MD", "RU", "UA", "US" };
        static async Task Main() // The entry point of the program
        {
            await Test(); // Calls the API method
        }

        
        static int? ValidateUserInput(string userInput)
        {
            if (DateTime.TryParseExact(userInput, // Tries to parse the input
                    "yyyy-MM-dd", // Using this format 
                    CultureInfo.InvariantCulture, // Independently of system settings
                    DateTimeStyles.None, // Preventing automatic modifications
                    out DateTime dateObj)) // Returning the dateObj
            {
                return dateObj.Year;
            }
            else
            {
                Console.WriteLine("❌ [DateError] --- Invalid date format. Please follow the format YYYY-MM-DD.");
                return null; // Return null to indicate failure
            }
        }
        
        static async Task<string> MakeApiCall(int? year, string country)
        {
            string api_url = $"https://date.nager.at/api/v3/PublicHolidays/{year}/{country}";
            using (HttpClient holidaysClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await holidaysClient.GetAsync(api_url);
                    response.EnsureSuccessStatusCode();
                    string jsonData = await response.Content.ReadAsStringAsync();
                    return jsonData;
                }
                
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Request error: {ex.Message}");
                }
                catch (JsonException ex) // Step 9: Handle JSON parsing errors
                {
                    Console.WriteLine($"JSON parsing error: {ex.Message}");
                }
            }

            return null;
        }
        
        static async Task<string> CountryApiCall(string country)
        {
            string api_url = $"https://date.nager.at/api/v3/CountryInfo/{country}";
            using (HttpClient countryClient = new HttpClient())
            {
                HttpResponseMessage response = await countryClient.GetAsync(api_url);
                response.EnsureSuccessStatusCode();
                string jsonData = await response.Content.ReadAsStringAsync();
                return jsonData;
            }
        }

        static void PrintHolidays(string holidaysApi, string countriesApi, string userInput)
        {
            List<PublicHoliday>? holidays = JsonSerializer.Deserialize<List<PublicHoliday>>(holidaysApi);
            CountryInfo? country = JsonSerializer.Deserialize<CountryInfo>(countriesApi);

            List<string> matchingHolidays = holidays
                .Where(h => h.date == userInput)
                .Select(h => h.localName)
                .ToList();

            if (matchingHolidays.Any())
            {
                Console.WriteLine("Matching Holidays:");
                foreach (string holiday in matchingHolidays)
                {
                    Console.WriteLine($"\nPublic Holiday(s) on {userInput} in {country?.officialName}:");
                    Console.WriteLine(holiday, "\n");
                }
            }
            else
            {
                Console.WriteLine($"\nNo public holidays found on {userInput} in {country?.officialName}");
            }
        }
        
        static async Task Test()
        {
            while (true)
            {
                Console.Write("Please enter the date you are interested in (YYYY-MM-DD): ");
                string userInput = Console.ReadLine().Trim();

                int? year = ValidateUserInput(userInput);
                
                if (year != null)
                {
                    Console.WriteLine($"✅ Valid date! Extracted Year: {year}");
                }

                foreach (string country in countryCode)
                {
                    string api_response = await MakeApiCall(year, country);
                    string api_response2 = await CountryApiCall(country);
                    PrintHolidays(api_response, api_response2, userInput);
                }
                
            }
        }

    } 
}

    internal class PublicHoliday
    { // This class is required so I can deserialise data from API response
        // We get the values from response and set them.
        public string date { get; set; }
        public string localName { get; set; }
        public string name { get; set; }
    }

    internal class CountryInfo
    {
        public string officialName { get; set; }
    }
