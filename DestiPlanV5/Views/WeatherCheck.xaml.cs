using DestiPlanv5.Models;

namespace DestiPlanv5.Views;

public partial class WeatherCheck : ContentPage
{
	public WeatherCheck()
	{
		InitializeComponent();
	}
    private async void OnClickedGetWeatherInfo(object sender, EventArgs e)
    {
        try
        {
            string WeatherInput = MyInput.Text;
            Weather weather = await ViewModel.WeatherCheckViewModel.GetWeatherAsync(WeatherInput);
            string cityWeatherInfo = "";


            if (weather != null)
            { 
                Temp.Text = $"Temperatur: {weather.temp}°C";
                FeelsLike.Text = $"Känns som: {weather.feels_like}°C";
                MinMaxTemp.Text = $"Min/Max Temperatur: {weather.min_temp}°C / {weather.max_temp}°C";
                Hum.Text = $"Luftfuktighet: {weather.humidity}%";
                CloudPct.Text = $"Molnighet: {weather.cloud_pct}%";
                if (weather.cloud_pct < 20)
                {
                    WeatherImage.Source = ImageSource.FromFile("sun.png");
                }
                else if (weather.cloud_pct >= 20 && weather.cloud_pct < 70)
                {
                    WeatherImage.Source = ImageSource.FromFile("hshc.png");
                }
                else
                {
                    WeatherImage.Source = ImageSource.FromFile("cloud.png");
                    cityWeatherInfo = $"I {WeatherInput} är det molnigt.";
                }

            }
            else
            {
              
                Console.WriteLine("Väder hittades inte eller GetWeatherAsync returnerade null.");
            }
        }
        catch (Exception ex)
        {
          
            Console.WriteLine($"Error i metoden OnClickedGetWeatherInfo: {ex.Message}");
        }
    }

}
