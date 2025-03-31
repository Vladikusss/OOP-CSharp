/*
 * Created by Vladdy | 31.03.2025
 * Last Updated: 31.03.2025
 * Program: Simple requests practice program
 * Version: 1.1
 * Status: In Progress
 * Can Be Improved: Yes
*/

using System;
using System.Net.Http; // HttpClient lives here
using System.Threading.Tasks;
using System.IO; // Used for logging
using HtmlAgilityPack; // To parse html

namespace Requestium;

internal class Program
{

    static async Task Main()
    {
        Logger.ClearLogs();
        await GoogleSearch();
    }
    
    static async Task GoogleSearch()
    {
        Logger.Log("INFO", "Google Search Function Started");
        using (HttpClient browserClient = new HttpClient())
        {
            Console.WriteLine("What do you want to search for?");
            string searchQuery = Console.ReadLine().ToLower();
            
            string googlUrl = $"https://www.google.com/search?q={searchQuery}";
            
            HttpResponseMessage response = await browserClient.GetAsync(googlUrl);
            
            Logger.Log("INFO", "Search Started");
            Logger.Log("INFO", $"Searching for {searchQuery}");
            if (response.IsSuccessStatusCode)
            {
                Logger.Log("INFO", "Google Search Completed Successfully.");
                string content = await response.Content.ReadAsStringAsync();
                
                Logger.Log("INFO", "Parsing HTML result");
                HtmlDocument webDocObj = new HtmlDocument();
                webDocObj.LoadHtml(content);
                Logger.Log("INFO", "Parsing Completed");
                
                var links = webDocObj.DocumentNode.SelectNodes("//a[@href]");
                Logger.Log("INFO", $"Found {links.Count} links");

                if (links != null)
                {
                    Logger.Log("INFO", $"Printing links");
                    Console.WriteLine("Found the following links:");
                    foreach (HtmlNode link in links)
                    {
                        string href = link.GetAttributeValue("href", string.Empty);
                        // If it's a relative URL, prepend the base URL
                        if (!href.StartsWith("http"))
                        {
                            href = "https://www.google.com" + href;
                        }

                        Console.WriteLine($"-- {href}");
                        
                    }
                    Logger.Log("INFO", $"Printed all available links");
                } else { Logger.Log("INFO", "No links found"); Console.WriteLine("No links found"); return; }
            }
            else
            {
                Logger.Log("ERROR", "Google Search Failed", (int)response.StatusCode);
            }
        }
    }
    static async Task APIexample()
    {
        using (HttpClient browserClient = new HttpClient())
        {
            Logger.Log("INFO", "Client Started.");
            string url = "https://jsonplaceholder.typicode.com/posts/1";
            HttpResponseMessage response = await browserClient.GetAsync(url);

            if (response.IsSuccessStatusCode) // Range: 200-299
            {
                string data = await response.Content.ReadAsStringAsync();
                Console.WriteLine(data);
                Logger.Log("INFO", "Successfully retrieved data from url", (int)response.StatusCode);
            }
            else
            {
                Logger.Log("ERROR", "Something went wrong with GET request", (int)response.StatusCode);
            }
        }
    }
}

