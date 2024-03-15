namespace DestiPlanv5.Views;

public partial class ConvertCurrency : ContentPage
{
	public ConvertCurrency()
	{
		InitializeComponent();
	}

    private async void OnClickedGoConvertCurrency(object sender, EventArgs e)
    {
        try
        {
            string have = Have.Text;
            string want = Want.Text;

            double amount;
            if (double.TryParse(Amount.Text, out amount))
            {
               
                Models.ConvertCurrency convertCurrency = await ViewModel.ConvertCurrencyViewModel.GetCoversionAsync(have, want, amount);

              
                if (convertCurrency != null)
                {
                    ConvertedAmount.Text = $"Konverterat belopp: {convertCurrency.new_amount} {convertCurrency.new_currency}";
                    OriginalAmount.Text = $"Ursprungligt belopp: {convertCurrency.old_amount} {convertCurrency.old_currency}";

                }
            }
            else
            {
                
                Console.WriteLine("Felaktig inmatning för belopp.");
            }
        }
        catch (Exception ex)
        {
           
            Console.WriteLine("Ett fel inträffade: " + ex.Message);
        }
    }


}


