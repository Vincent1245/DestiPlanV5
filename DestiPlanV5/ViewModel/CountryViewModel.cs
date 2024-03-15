using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DestiPlanv5.ViewModel
{
    internal class CountryViewModel
    {
        public static async Task<List<Models.Country>> GetCountryAsync(string CountryInput)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.api-ninjas.com/");
            client.DefaultRequestHeaders.Add("X-Api-Key", "JTyzBxqEEBjlHdsxg4BYJw==uDp7cVnw9LjRRxhW");
            List<Models.Country> country = null;

            HttpResponseMessage response = await client.GetAsync($"v1/country?name={CountryInput}");
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                country = JsonSerializer.Deserialize<List<Models.Country>>(responseString);
            }

            return country;
        }
           


    }
}
