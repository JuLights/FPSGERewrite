using FPSGERewrite.Software.Models;
using System.Collections.ObjectModel;
using Keyboard = FPSGERewrite.Software.Models.Keyboard;

namespace FPSGERewrite.Software.Views;

public partial class HomePage : ContentPage
{
    public List<Mouse> Mouses { get; set; }
    public List<Keyboard> Keyboards { get; set; }
    public HomePage()
    {
        InitializeComponent();
    }

    public HomePage(List<Keyboard> keyboards)
    {
        InitializeComponent();

        Keyboards = keyboards;

        foreach (var keyboard in keyboards)
        {
            if (keyboard.ImageData != null)
            {
                MemoryStream memory = new MemoryStream(keyboard.ImageData);
                keyboard.Src = ImageSource.FromStream(() => (Stream)memory);
            }
            
        }

        

        BindingContext = this;


    }

}