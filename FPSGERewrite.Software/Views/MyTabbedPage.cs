using FPSGERewrite.Software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSGERewrite.Software.Views
{
    public class MyTabbedPage : TabbedPage
    {
        public MyTabbedPage()
        {
            this.Title = "MyTabbedPagae";
            var list = new List<FPSGERewrite.Software.Models.Keyboard>();
            this.Padding = new Thickness(0, 0, 0, 25);
            Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific.TabbedPage.SetToolbarPlacement(this, Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific.ToolbarPlacement.Bottom);
            this.Children.Add(new ContentPage
            {
                Title = "Blue",
                Content = new BoxView
                {
                    Color = Colors.Blue,
                    HeightRequest = 100f,
                    VerticalOptions = LayoutOptions.Center
                },
            }
        );
            this.Children.Add(new HomePage(list));
        }
    }
}
