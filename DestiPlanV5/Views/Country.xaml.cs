namespace DestiPlanv5.Views;


public partial class Country : ContentPage
{
	public Country()
	{
		InitializeComponent();
	}

    private async void OnClickedGetCountryInfo(object sender, EventArgs e)
    {
        try
        {
            string countryInput = UserInput.Text;
            if (string.IsNullOrWhiteSpace(countryInput))
            {
                Console.WriteLine("Ange ett giltigt landsnamn.");
                return;
            }
            Models.Country country = (await ViewModel.CountryViewModel.GetCountryAsync(countryInput)).FirstOrDefault();
            if (country != null)
            {
                CountryName.Text = $"Land: {country.name}";
                Capital.Text = $"Huvudstad: {country.capital}";
                Pop.Text = $"Antal invånare: {country.population/1000} Miljoner";
                LifeExpM.Text = $"Förväntad livslängd Man: {country.life_expectancy_male} år";
                LifeExpF.Text = $"Förväntad livslängd Kvinna: {country.life_expectancy_female} år";
                Currency.Text = $"Valuta: {country.currency.name} {country.currency.code}";
                Internet.Text = $"Internetanvändare: {country.internet_users}%";
                Unemployment.Text = $"Arbetslöshet: {country.unemployment}%";

            }
            else
            {
                Console.WriteLine("Land hittades inte eller GetCountryAsync returnerade null.");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error i metoden OnClickedGetCountryInfo: {ex.Message}");
        }

    }

}