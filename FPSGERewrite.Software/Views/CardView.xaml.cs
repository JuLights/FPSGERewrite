namespace FPSGERewrite.Software.Views;

public partial class CardView : ContentView
{
    public static readonly BindableProperty CardBackgroundProperty = BindableProperty.Create(nameof(CardBackground), typeof(Color), typeof(CardView), default(Color),BindingMode.TwoWay, null,
        BackgroundColorPropertyChanged);

    public static readonly BindableProperty CardNumberTextProperty = BindableProperty.Create(nameof(CardNumberText), typeof(string), typeof(CardView), default(string), BindingMode.OneWay, null,
        CardNumberPropertyChanged);

    public static readonly BindableProperty ExpireDateTextProperty = BindableProperty.Create(nameof(ExpireDateText), typeof(string), typeof(CardView), default(string), BindingMode.OneWay, null,
        ExpireDatePropertyChanged);

    public CardView()
	{
		InitializeComponent();
	}

    public Color CardBackground 
    { 
        get => (Color)GetValue(CardBackgroundProperty);
        set => SetValue(CardBackgroundProperty, value); 
    }

    private static void BackgroundColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CardView)bindable;
        control.CustomFrame.BackgroundColor = (Color)newValue;
    }

    public string CardNumberText
    {
        get => (string)GetValue(CardNumberTextProperty); 
        set => SetValue(CardNumberTextProperty, value);
    }

    private static void CardNumberPropertyChanged(BindableObject bindable, object oldValue, object newValue) 
    {
        var control = (CardView)bindable;
        control.CardNumber.Text = (string)newValue;
    }

    public string ExpireDateText 
    { 
        get => (string)GetValue(ExpireDateTextProperty);
        set => SetValue(ExpireDateTextProperty, value); 
    }

    private static void ExpireDatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CardView)bindable;
        control.ExpireDate.Text = (string)newValue;
    }
}