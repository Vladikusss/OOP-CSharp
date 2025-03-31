using System;
using System.Net.Http; // HttpClient lives here
using System.Threading.Tasks;
using System.IO; // Used for logging


namespace Requestium; 

internal class Program {
    
    static async Task Main()
    {
        Logger.ClearLogs();
        using (HttpClient browserClient = new HttpClient())
        {   
            Logger.Log("INFO", "Client Started.");
            string url = "https://jsonplaceholder.typicode.com/pots/1";
            HttpResponseMessage response = await browserClient.GetAsync(url);
            
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                Console.WriteLine(data);
                Logger.Log("INFO", "Successfully retrieved.");
            }
            else 
            { 
                Logger.Log("ERROR", "Something went wrong with GET request", response.StatusCode.ToString());
            }

        }
    }
}