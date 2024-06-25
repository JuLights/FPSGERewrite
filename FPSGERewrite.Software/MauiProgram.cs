using CommunityToolkit.Maui;
using FPSGERewrite.Software.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using The49.Maui.BottomSheet;
using IeuanWalker.Maui.Switch;

namespace FPSGERewrite.Software
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();


            //services
            builder.Services.AddSingleton(typeof(IProductService),typeof(ProductsService));
            //builder.Services.AddLogging(
            //configure =>
            //{
            //    configure.AddDebug();
            //    configure.AddConsole();
            //});

            builder
                .UseMauiApp<App>()
                .UseSwitch()
                .UseBottomSheet()
                .UseMauiCommunityToolkit()
                .ConfigureLifecycleEvents(events =>
                {
#if ANDROID
                events.AddAndroid(android => android.OnCreate((activity, bundle) => MakeStatusBarTranslucent(activity)));

                static void MakeStatusBarTranslucent(Android.App.Activity activity)
                {
                    activity.Window.SetFlags(Android.Views.WindowManagerFlags.LayoutNoLimits, Android.Views.WindowManagerFlags.LayoutNoLimits);

                    activity.Window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);

                    activity.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
                }
#endif
                })
                //.ConfigureMauiHandlers(handler =>
                //{
                    
                //})
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                    fonts.AddFont("Philosopher-Bold.ttf", "PhilosopherBold");
                    fonts.AddFont("Philosopher-BoldItalic.ttf", "PhilosopherBoldItalic");
                    fonts.AddFont("Philosopher-Italic.ttf", "PhilosopherItalic");
                    fonts.AddFont("Philosopher-Regular.ttf", "PhilosopherRegular");

                    fonts.AddFont("Roboto-Bold.ttf", "RobotoBold");
                    fonts.AddFont("Roboto-Light.ttf", "RobotoLight");
                    fonts.AddFont("Roboto-Medium.ttf", "RobotoMedium");
                    fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
                    fonts.AddFont("Roboto-Thin.ttf", "RobotoThin");
                });

            

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
#if ANDROID
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#endif
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
