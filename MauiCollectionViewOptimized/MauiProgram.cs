using MauiCollectionViewOptimized.Services;
using MauiCollectionViewOptimized.Services.Interfaces;
using MauiCollectionViewOptimized.ViewModels;
using Microsoft.Extensions.Logging;

namespace MauiCollectionViewOptimized
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseVirtualListView()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddHttpClient<IMainService, MainService>();
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<WithVirtualListViewModel>();
            builder.Services.AddScoped<MainPage>();
            builder.Services.AddScoped<WithVirtualList>();

            return builder.Build();
        }
    }
}
