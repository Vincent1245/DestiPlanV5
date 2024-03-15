namespace DestiPlanv5.Views;

public partial class MainMenu : ContentPage
{
	public MainMenu()
	{
		InitializeComponent();
	}

    private async void OnClickedGoMyTrips(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MyTrips());
    }

    private async void OnClickedGoWeatherCheck(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WeatherCheck());
    }

    private async void OnClickedGoSearchTicket(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SearchTicket());
    }

    private async void OnClickedGoCountry(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Country());
    }

    private async void OnClickedGoConvertCurrency(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ConvertCurrency());
    }
}
