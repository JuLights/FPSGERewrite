using FPSGERewrite.Software.Models;
using FPSGERewrite.Software.Views;
using System.Collections.ObjectModel;

namespace FPSGERewrite.Software
{
    public partial class App : Application
    {
        public static ObservableCollection<FPSGERewrite.Software.Models.Keyboard> Keyboards { get; set; }
        public static IServiceProvider Services;
        public App(IServiceProvider services)
        {
            InitializeComponent();

            Services = services;
            MainPage = new NavigationPage(new LoginPage());
        }
    }
}
