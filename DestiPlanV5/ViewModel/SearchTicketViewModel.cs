using Amazon.Runtime.Credentials.Internal;
using DestiPlanv5.Data;
using DestiPlanv5.Models;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DestiPlanv5.ViewModel
{
    internal class SearchTicketViewModel
    {
        public static async Task<Models.Ticket> GetTicketOffersAsync(Ticket requestTicket)
        {
            var token = await GetAmadeusToken.GetToken();
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://test.api.amadeus.com/v2/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                Models.Ticket responseTicket = null; 

                HttpResponseMessage response = await client.GetAsync($"{client.BaseAddress}shopping/flight-offers?originLocationCode={requestTicket.DepartureLocationCode}&destinationLocationCode={requestTicket.ArrivalLocationCode}&departureDate={requestTicket.DepartureTime}&adults={requestTicket.NoOfPeople}&nonStop=false&max=1");

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    responseTicket = JsonSerializer.Deserialize<Models.Ticket>(responseString);
                }

                return responseTicket;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error i GetTicketOffersAsync: {ex.Message}");
                return null;
            }
        }
    }

}

