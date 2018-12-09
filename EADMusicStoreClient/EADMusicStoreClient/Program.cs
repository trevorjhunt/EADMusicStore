using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EADmusicStoreClient
{
    class Program
    {
        // main entry point
        static void Main(string[] args)
        {
            HttpClient myClient = null;

            // set the console
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            try
            {
                myClient = new HttpClient();
                myClient.BaseAddress = new Uri("http://localhost:57867/");
                myClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to create HttpClient - program exiting");
                return;
            }

            GetAllAlbumsAsync(myClient).Wait();
            Console.ReadKey();
        }


        // get all albums 
        private static async Task GetAllAlbumsAsync(HttpClient myClient)
        {
            try
            {
                // Sent request for all properties
                HttpResponseMessage response = await myClient.GetAsync("api/albums");

                // request code was successful?
                if (response.IsSuccessStatusCode)
                {
                    // read results 
                    var albums = await response.Content.ReadAsAsync<IEnumerable<string>>();

                    Console.WriteLine("\n LIST OF ALBUMS");
                    Console.WriteLine("----------------------------------------------\n");

                    Console.ForegroundColor = ConsoleColor.White;
                    foreach (var p in albums)
                        Console.WriteLine(p);

                }
                else
                {
                    Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
