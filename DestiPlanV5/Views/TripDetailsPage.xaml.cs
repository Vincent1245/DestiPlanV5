using MongoDB.Driver;

namespace DestiPlanv5.Views;

public partial class TripDetailsPage : ContentPage
{
	public TripDetailsPage()
	{
		InitializeComponent();
	}

    private async void OnClickedUpdateTrip(object sender, EventArgs e)
    {
		var trip = ((Button)sender).BindingContext as Models.Trip;
		await Navigation.PushAsync(new MyTripAdminPage(trip));
    }

    private async void OnClickedDeleteTrip(object sender, EventArgs e)
    {
        var trip = ((Button)sender).BindingContext as Models.Trip;
        var filter = Builders<Models.Trip>.Filter.Eq(x => x.Id, trip.Id);
        await Data.Db.TripCollection().DeleteOneAsync(filter);
        await Navigation.PushAsync(new MyTrips());
        
        
    }

   
}