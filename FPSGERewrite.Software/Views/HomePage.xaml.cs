using Newtonsoft.Json;
using FPSGERewrite.Software.Models;
using System.Collections.ObjectModel;

namespace FPSGERewrite.Software.Views;

public partial class HomePage : ContentPage
{
    public ObservableCollection<Mouse> Mouse { get; set; } = new ObservableCollection<Mouse>();

    public HomePage(List<Mouse> mice)
    {
        InitializeComponent();

        foreach (var mouse in mice)
        {
            Mouse.Add(mouse);
        }

        BindingContext = this;

        
    }

}