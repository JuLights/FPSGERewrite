using The49.Maui.BottomSheet;

namespace FPSGERewrite.Software.Views;

public partial class ProductSheet : BottomSheet
{
	public ImageSource Src { get; set; }
	public string Brand { get; set; }
	public string Description { get; set; }
	public decimal Price { get; set; }
	public int Count { get; set; }
    private FPSGERewrite.Software.Models.Keyboard _keyboard;



    public ProductSheet(FPSGERewrite.Software.Models.Keyboard keyboard)
	{
        _keyboard = keyboard;
		Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry." +
			" Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown " +
			"printer took a galley of type and scrambled it to make a type specimen book. It has survived not " +
			"only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.";

		Brand = keyboard.Brand;
		Price = (decimal)99.48;
		Count = 1;

        InitializeComponent();

		BindingContext = this;

    }

    private void Decrease_Tapped(object sender, TappedEventArgs e)
    {
		
		if (Count > 1)
		{
            Count--;
            Cnt.Text = Count.ToString();
        }
        
    }

    private void Increase_Tapped(object sender, TappedEventArgs e)
    {
        Count++;
        Cnt.Text = Count.ToString();
    }

    private async void Buy_Clicked(object sender, EventArgs e)
    {
        await this.DismissAsync(true);

        await App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new CheckoutPage(_keyboard)));

        //await Navigation.PushAsync(new CheckoutPage());
    }
}