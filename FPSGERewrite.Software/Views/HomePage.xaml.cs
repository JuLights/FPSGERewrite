using FPSGERewrite.Software.Converters;
using FPSGERewrite.Software.Models;
using FPSGERewrite.Software.Services;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Keyboard = FPSGERewrite.Software.Models.Keyboard;

namespace FPSGERewrite.Software.Views;

public partial class HomePage : ContentPage
{
    public List<Mouse> Mouses { get; set; }
    public ObservableCollection<Keyboard> Keyboards { get; set; }
    IProductService _productService;
    private bool isFetched = false;
    public HomePage()
    {
        InitializeComponent();

        _productService = App.Services.GetService<IProductService>();
        var ImageSourceService = App.Services.GetService<ImageSourceService>();
        Keyboards = new ObservableCollection<Keyboard>(Task.Run(() => _productService?.GetProductsAsync("https://juiznogoud.azurewebsites.net/api/Keyboard/GetAll")).Result);
        //Keyboards = Task.Run(() => _productService?.GetProductsAsync("https://juiznogoud.azurewebsites.net/api/Keyboard/GetAll")).Result;

        BindingContext = this;
    }

    public HomePage(List<Keyboard> keyboards)
    {
        InitializeComponent();

        //Keyboards = keyboards;

        //var imageManagerDiskCache = Path.Combine(FileSystem.CacheDirectory, "image_manager_disk_cache");

        //if (Directory.Exists(imageManagerDiskCache))
        //{
        //    foreach (var imageCacheFile in Directory.EnumerateFiles(imageManagerDiskCache))
        //    {
        //        File.Delete(imageCacheFile);
        //    }
        //}

        //StreamImageSourceService.

        //string cacheDir = FileSystem.Current.CacheDirectory;
        //string mainDir = FileSystem.Current.AppDataDirectory;

        //foreach (var keyboard in keyboards)
        //{
        //    if (keyboard.ImageData != null)
        //    {
        //        MemoryStream memory = new MemoryStream(keyboard.ImageData);
        //        keyboard.Src = ImageSource.FromStream(() => (Stream)memory);
        //    }

        //}

        isFetched = true;

        BindingContext = this;
    }

    protected override void OnDisappearing()
    {
        //foreach (var keyboard in Keyboards)
        //{
        //    keyboard.Base64Image = (string)new Base64ToImageSourceConverter().ConvertBack(keyboard.Base64Image, typeof(string), null, null);
        //}

        //CurrentKeyboard.Base64Image = (string)new Base64ToImageSourceConverter().ConvertBack(CurrentKeyboard.Src, typeof(string), null, null);

        base.OnDisappearing();
    }

    protected async override void OnAppearing()
    {
        //if (!isFetched)
        //{
        //    try
        //    {
        //        Keyboards = new List<Keyboard>();
        //        using (var httpClient = new HttpClient())
        //        {
        //            var response = await httpClient.GetAsync("https://juiznogoud.azurewebsites.net/api/Keyboard/GetAll");
        //            response.EnsureSuccessStatusCode();

        //            var content = await response.Content.ReadAsStringAsync();
        //            if (content is not null)
        //            {
        //                Keyboards = JsonConvert.DeserializeObject<List<Keyboard>>(content);
        //                //foreach (var keyboard in Keyboards)
        //                //{
        //                //    if (keyboard.ImageData != null)
        //                //    {
        //                //        MemoryStream memory = new MemoryStream(keyboard.ImageData);
        //                //        keyboard.Src = ImageSource.FromStream(() => (Stream)memory);
        //                //    }

        //                //}
        //                Keyboards.Reverse();

        //                //await Navigation.PushAsync(new HomePage(keyboardList));
        //            }
        //            else
        //            {
        //                await DisplayAlert("Error", $"An error occurred: Content is null", "OK");
        //            }


        //        }
        //    }
        //    catch (Exception ex) 
        //    {
        //        await DisplayAlert("App Error", ex.Message, "Ok");
        //    }
            
        //}
        

        base.OnAppearing();
    }


    ProductSheet productSheet;
    private bool isSheetShown = false;
    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Debug.WriteLine("heyyyyy");
        if (e.CurrentSelection != null)
        {
            var item = (Keyboard)e.CurrentSelection.FirstOrDefault();
            if (item != null)
            {
                isFetched = false;
                await App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new ProductDetailPage(item)));
                //await Navigation.PushAsync(new NavigationPage(new ProductDetailPage(item)));

                ((CollectionView)sender).SelectedItem = null;
            }
        }

        
        
    }

    private void ProductSheet_Dismissed(object? sender, The49.Maui.BottomSheet.DismissOrigin e)
    {
        isSheetShown = false;
    }
}