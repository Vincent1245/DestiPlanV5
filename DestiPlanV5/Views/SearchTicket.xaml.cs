using DestiPlanv5.Models;
using DestiPlanv5.ViewModel;

namespace DestiPlanv5.Views;

public partial class SearchTicket : ContentPage
{
	public SearchTicket()
	{
		InitializeComponent();
	}

    private async void OnClickedGetTicketInfo(object sender, EventArgs e)
    {
        Console.WriteLine("Metoden körs");
        string departureAirport = DepartureAirport.Text;
        string arrivalAirport = ArrivalAirport.Text;
        DateTime departingDate = Departing.Date;
        DateTime returningDate = Returning.Date;
        int numberOfPassengers = int.Parse(NoOfPeople.Text);

        Ticket userTicket = new Ticket
        {
            NoOfPeople = numberOfPassengers,
            DepartureLocationCode = departureAirport,
            ArrivalLocationCode = arrivalAirport,
            DepartureTime = departingDate,
            ArrivalTime = returningDate,
            PriceTotal = 0, 
            CarrierCode = "XYZ" 
        };
        Ticket apiResponse = await SearchTicketViewModel.GetTicketOffersAsync(userTicket);

        if (apiResponse != null)
        {

            TicketPriceLabel.Text = $"Pris: {apiResponse.PriceTotal} EUR";


        }
        else
        {
            Console.WriteLine("Flygbiljettinformation hittades inte eller GetTicketOffersAsync returnerade null.");
        }
    }
    
}
