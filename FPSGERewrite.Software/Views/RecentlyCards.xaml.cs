namespace FPSGERewrite.Software.Views;

public partial class RecentlyCards : ContentView
{
	public static readonly BindableProperty ImgSourceProperty = BindableProperty.Create(nameof(ImgSource), typeof(ImageSource), typeof(RecentlyCards), null,BindingMode.TwoWay,
		null, ImgSourcePropertyChanged);

	public static readonly BindableProperty BrandLabelProperty = BindableProperty.Create(nameof(BrandLabel), typeof(string), typeof(RecentlyCards), null, BindingMode.TwoWay, null,
		(o, ol, n) =>
		{
			var control = (RecentlyCards)o;
			control.BrndLabel.Text = (string)n;
		});

	public static readonly BindableProperty PriceLabelProperty = BindableProperty.Create(nameof(PriceLabel), typeof(string), typeof(RecentlyCards), null, BindingMode.TwoWay, null,
		(o, ol, n) =>
		{
			var control = (RecentlyCards)o;
			control.PrcLabel.Text = (string)n;
		});



	public RecentlyCards()
	{
		InitializeComponent();
	}

    private static void ImgSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
	{
		var control = (RecentlyCards)bindable;
		control.ImgSr.Source = (ImageSource)newValue;
	}

	public string BrandLabel
	{
		get => (string)GetValue(BrandLabelProperty);
		set => SetValue(BrandLabelProperty, value);
	}

	public string PriceLabel
    {
		get => (string)GetValue(PriceLabelProperty);
		set => SetValue(PriceLabelProperty,value);
	}

    public ImageSource ImgSource
	{
		get => (ImageSource)GetValue(ImgSourceProperty);
		set => SetValue(ImgSourceProperty,value);
	}


}