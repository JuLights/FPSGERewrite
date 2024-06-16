using FPSGERewrite.Software.Views;

namespace FPSGERewrite.Software
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }
    }
}
