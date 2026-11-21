
using Microsoft.EntityFrameworkCore;
using ShopApp.DataAcces;
using ShopApp.Views;
using ShopApp.Services;
using ShopApp.ViewModels;

namespace ShopApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont(
                    "OpenSans-Regular.ttf",
                    "OpenSansRegular");

                fonts.AddFont(
                    "OpenSans-Semibold.ttf",
                    "OpenSansSemibold");
            });

        // Registrar SQLite
        string ruta = Path.Combine(
            FileSystem.AppDataDirectory,
            "ShopComputer.db");

        builder.Services.AddDbContext<ShopDbContext>(
            options => options.UseSqlite(
                $"Data Source={ruta}"));

        // Registrar rutas
        Routing.RegisterRoute(
            nameof(ProductDetailPage),
            typeof(ProductDetailPage));

        Routing.RegisterRoute(
            nameof(HelpSupportDetailPage),
            typeof(HelpSupportDetailPage));

        // Servicio de navegación
        builder.Services.AddSingleton<
            INavegacionService,
            NavegacionService>();

        // ViewModel
        builder.Services.AddTransient<
            HelpSupportViewModel>();

        // Página Help Support
        builder.Services.AddTransient<
            HelpSupportPage>();

        return builder.Build();
    }
}
