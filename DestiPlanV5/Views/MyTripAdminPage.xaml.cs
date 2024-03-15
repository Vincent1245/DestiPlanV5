using MongoDB.Driver;

namespace DestiPlanv5.Views;

public partial class MyTripAdminPage : ContentPage
{
    public Models.Trip Trip { get; set; }
    public MyTripAdminPage(Models.Trip trip)
	{
		InitializeComponent();
		Trip = trip;

		if (trip!=null)
		{
			DestinationNameEntry.Text = trip.DestinationName;
			TripLengthEntry.Text = trip.TripLength.ToString();
			BudgetEntry.Text = trip.Budget.ToString();
			ImageSourceEntry.Text = trip.ImageSource;
			DetailsEntry.Text = trip.Details;
			SaveButton.Text = "Uppdatera resan";

		}
	}

    private async void OnClickedSaveProduct(object sender, EventArgs e)
    {
		if (Trip == null)
		{


			Models.Trip trips = new Models.Trip()
			{
				Id = Guid.NewGuid(),
				DestinationName = DestinationNameEntry.Text,
				TripLength = int.Parse(TripLengthEntry.Text),
				Budget = int.Parse(BudgetEntry.Text),
				ImageSource = ImageSourceEntry.Text,
				Details = DetailsEntry.Text,

			};
			await Data.Db.TripCollection().InsertOneAsync(trips);
		}

		else
		{
			Trip.DestinationName = DestinationNameEntry.Text;
			Trip.TripLength = int.Parse(TripLengthEntry.Text);
			Trip.Budget = int.Parse(BudgetEntry.Text);
			Trip.ImageSource = ImageSourceEntry.Text;
			Trip.Details = DetailsEntry.Text;

			var filter = Builders<Models.Trip>.Filter.Eq(x => x.Id, Trip.Id);
			await Data.Db.TripCollection().ReplaceOneAsync(filter, Trip);
		}



		await Navigation.PushAsync(new MyTrips());
    }
}