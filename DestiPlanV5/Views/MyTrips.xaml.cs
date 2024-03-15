using DestiPlanv5.Models;

namespace DestiPlanv5.Views;

public partial class MyTrips : ContentPage
{
	public MyTrips()
	{
		InitializeComponent();
        BindingContext = new ViewModel.MyTripViewModel();
    }

    private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var trip = ((ListView)sender).SelectedItem as Models.Trip;
        if (trip != null)
        {
            var page = new TripDetailsPage();
            page.BindingContext = trip;
            await Navigation.PushAsync(page);


        }
    }

    private async void OnClickedGoMyTripAdminPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.MyTripAdminPage(null));
    }
}