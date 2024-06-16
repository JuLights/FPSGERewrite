using FPSGERewrite.Software.Models;
using Newtonsoft.Json;

namespace FPSGERewrite.Software.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void SkipGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://juiznogoud.azurewebsites.net/api/Mouse/GetAll");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var mouseList = JsonConvert.DeserializeObject<List<Mouse>>(content);

                await Navigation.PushAsync(new NavigationPage(new HomePage(mouseList)));
            }
        }
        catch(Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
        
        


        
    }
}