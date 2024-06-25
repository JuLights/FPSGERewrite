using FPSGERewrite.Software.Models;
using Newtonsoft.Json;
using Keyboard = FPSGERewrite.Software.Models.Keyboard;

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
            List<Keyboard> keyboardList;
            await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            //await Navigation.PushAsync(new HomePage());
            //using (var httpClient = new HttpClient())
            //{
            //    var response = await httpClient.GetAsync("https://juiznogoud.azurewebsites.net/api/Keyboard/GetAll");
            //    response.EnsureSuccessStatusCode();

            //    var content = await response.Content.ReadAsStringAsync();
            //    if(content is not null)
            //    {
            //        keyboardList = JsonConvert.DeserializeObject<List<Keyboard>>(content);
            //        keyboardList.Reverse();

            //        await Navigation.PushAsync(new HomePage(keyboardList));
            //    }
            //    else
            //    {
            //        await DisplayAlert("Error", $"An error occurred: Content is null", "OK");
            //    }


            //}
        }
        catch(Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
        
        


        
    }
}