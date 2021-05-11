using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json;
using WebAPIClient;

namespace NgpApiClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            var services = new ApiServices();
            var response = await services.GetInfo("5D2C2ACD-2342-4DFB-80F5-8086C8065DA1");
            if (response == null)
            {
                Console.WriteLine("Failed to retrieve results");
                //todo: Error handling
                // return status code and message in a result object with property code and message
            } else
            {
                foreach (var email in response.items)
                    Console.WriteLine($"{email.emailMessageId} {email.name}");

                Console.WriteLine($"Total: {response.count}");
            }


        }

        
    }
}
