using The49.Maui.BottomSheet;

namespace FPSGERewrite.Software.Views;

public partial class ProductDetailPage : ContentPage
{
    private readonly FPSGERewrite.Software.Models.Keyboard _keyboard;
    public ImageSource Src { get; set; }
    ProductSheet productSheet;
    private bool isSheetShown = false;

    public ProductDetailPage()
	{
		InitializeComponent();
	}
    public ProductDetailPage(FPSGERewrite.Software.Models.Keyboard keyboard)
    {
        InitializeComponent();
        _keyboard = keyboard;
        productSheet = new(_keyboard);
        productSheet.CornerRadius = 40;
        productSheet.Dismissed += ProductSheet_Dismissed;
        MemoryStream memory = new MemoryStream(_keyboard.ImageData);
        Src = ImageSource.FromStream(() => (Stream)memory);
        //memory.Dispose();
        
        BindingContext = this;
    }

    private void ProductSheet_Dismissed(object? sender, DismissOrigin e)
    {
        isSheetShown = false;
    }

    protected async override void OnAppearing()
    {
        // do something useful with item
        if (!isSheetShown)
        {
            await productSheet.ShowAsync(true);
            
            isSheetShown = true;

        }
        base.OnAppearing();
    }

    protected override bool OnBackButtonPressed()
    {
        MainThread.BeginInvokeOnMainThread(async () => await App.Current.MainPage.Navigation.PopAsync());

        return base.OnBackButtonPressed();
    }

}