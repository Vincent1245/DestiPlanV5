using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DestiPlanv5.Data
{
    public class GetAmadeusToken
    {
        public static async Task<string> GetToken()
        {
            {
                string clientId = "wsQImDBEpXgbBBo3yQS289Es7QzSvEd2";
                string clientSecret = "AdEAzBHERTeFT4xU";

        
                string tokenEndpoint = "https://test.api.amadeus.com/v1/security/oauth2/token";

             
                var requestData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("client_secret", clientSecret)
                });

              
                using (var client = new HttpClient())
                { 
                    requestData.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");

                    var response = await client.PostAsync(tokenEndpoint, requestData);

                 
                    if (response.IsSuccessStatusCode)
                    {
                        
                        string responseBody = await response.Content.ReadAsStringAsync();
                        string accessToken = null;

                        using (JsonDocument doc = JsonDocument.Parse(responseBody))
                        {
                         
                            JsonElement root = doc.RootElement;

                           
                            accessToken = root.GetProperty("access_token").GetString();

                       
                            Console.WriteLine($"Access Token: {accessToken}");
                        }
                        return accessToken;
                    }
                    else
                    {
                      
                        return $"Error: {response.StatusCode} - {response.ReasonPhrase}";

                    }
                }
            }

        }
    }
}
