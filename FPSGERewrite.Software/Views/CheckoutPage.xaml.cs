using FPSGERewrite.Software.Models;

namespace FPSGERewrite.Software.Views;

public partial class CheckoutPage : ContentPage
{
    public ImageSource Src { get; set; }
    public decimal Price { get; set; }
    public string Brand { get; set; }
    public List<Card> Cards { get; set; } = new List<Card>();
    public string CrdNumber { get; set; }
    public string ExpDate { get; set; }

    FinalizeSheet _finalizeSheet;
    public CheckoutPage()
	{
		InitializeComponent();
	}

    public CheckoutPage(FPSGERewrite.Software.Models.Keyboard keyboard)
    {
        InitializeComponent();
        _finalizeSheet = new FinalizeSheet();

        Cards.Add(new Card()
        {
            CardHolder = "DAVID JUGELI",
            CardNumber = "**** **** **** 4578",
            ExpirationDate = "04/26",
            CardColor = Color.FromRgba("#E27BC1")
        });
        Cards.Add(new Card()
        {
            CardHolder = "DAVID JUGELI",
            CardNumber = "**** **** **** 4876",
            ExpirationDate = "05/28",
            CardColor = Color.FromRgba("#A280C1")
        });

        CrdNumber = "**** **** **** 4578";
        ExpDate = "04/26";

        MemoryStream mem = new MemoryStream(keyboard.ImageData);

        Src = ImageSource.FromStream(() => mem);
        Price = (decimal)99.99;


        BindingContext = this;
    }

    protected override void OnAppearing()
    {
        _finalizeSheet.ShowAsync(true);
        base.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        _finalizeSheet.DismissAsync(true);
        base.OnDisappearing();
    }

    protected override bool OnBackButtonPressed()
    {
        Navigation.PopAsync();
        return base.OnBackButtonPressed();
    }
}