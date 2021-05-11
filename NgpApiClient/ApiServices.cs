using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WebAPIClient;

namespace NgpApiClient
{
    public class ApiServices
    {
        public async Task<Root> GetInfo(string authorizeToken)
        {
            // HTTP Request.  
            using (var client = new HttpClient())
            {
                // Init
                string authorization = authorizeToken;

                // Setting Base address.  
                client.BaseAddress = new Uri("https://api.myngp.com");

                // Setting content type.  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Setting Authorization.  
                client.DefaultRequestHeaders.Add("apiKey", authorization);

                // Initialization.  
                HttpResponseMessage response = new HttpResponseMessage();

                // HTTP GET  
                response = await client.GetAsync("/v2/broadcastEmails").ConfigureAwait(false);

                // Verification  
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();

                    jsonString.Wait();

                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(jsonString.Result);

                    return myDeserializedClass;
                }
            }

            return null;
        }
    }
}
