/*
 * Created by Vladdy | 23.02.2025
 * Last Updated: 24.02.2025
 * Program: API Testing in c#
 * Version: 2.0
 * Status: Completed.
 * Can Be Improved: Yes
 */

using System;
using System.Net.Http; // Used to make http calls
using System.Threading.Tasks; // Used for asynchronous operations
using System.Text.Json; // Used to parse json data
using System.Collections.Generic; // Used to make lists 

namespace Calendar
{
    internal class TestProgram
    {
        static async Task Main() // The entry point of the program
        {
            await Test(); // Calls the API method
        }
        static async Task Test()
        // async -> allows method to run asynchronously
        // Task can't be renamed, allows "await" usage
        {
            string url =  "https://date.nager.at/api/v3/PublicHolidays/2025/GB";

            // using -> ensures proper dispose of client
            using (HttpClient testClient = new HttpClient())
            {
                try
                {

                    // Send asynchronous GET request to the URL defined above
                    HttpResponseMessage response = await testClient.GetAsync(url);
                    response.EnsureSuccessStatusCode(); // 200 = success status code

                    // As we receive raw data as a string in JSON format, the variable must be a string
                    string jsonData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonData); // Print raw JSON data

                    // PublicHolidays -> reference to the class
                    // ? -> variable can be null
                    // jsonData -> data to deserialise into the list
                    List<PublicHoliday>? holidays = JsonSerializer.Deserialize<List<PublicHoliday>>(jsonData);

                    if (holidays != null)
                    {
                        foreach (var h in holidays)
                        {
                            Console.WriteLine($"{h.name} happens to be on {h.date} and is known as {h.localName}");
                        }
                    }
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
        }
        
    }

    internal class PublicHoliday
    { // This class is required so I can deserialise data from API response
        // We get the values from response and set them.
        public string date { get; set; }
        public string localName { get; set; }
        public string name { get; set; }
    }
    
}