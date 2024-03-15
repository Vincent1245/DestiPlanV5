using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DestiPlanv5.ViewModel
{
    internal class ConvertCurrencyViewModel
    {
        public static async Task<Models.ConvertCurrency> GetCoversionAsync(string have, string want, double amount)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://api.api-ninjas.com/");
                client.DefaultRequestHeaders.Add("X-Api-Key", "JTyzBxqEEBjlHdsxg4BYJw==uDp7cVnw9LjRRxhW");
                Models.ConvertCurrency convertCurrency = null;

                HttpResponseMessage response = await client.GetAsync($"v1/convertcurrency?have={have}&want={want}&amount={amount}");
           

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    convertCurrency = JsonSerializer.Deserialize<Models.ConvertCurrency>(responseString);
                }

                return convertCurrency;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetConversionAsync: {ex.Message}");
                return null;
            }
        }

       





    }
}
