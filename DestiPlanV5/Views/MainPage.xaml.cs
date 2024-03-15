namespace DestiPlanv5
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnClickedGoMainMenu(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.MainMenu());
        }
    }

}
