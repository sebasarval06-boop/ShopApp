using ShopApp.DataAcces; // <--- OJO: Con una sola 's' al final
using ShopApp.Views;

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
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Registrar la ruta de la página de detalle
        Routing.RegisterRoute(nameof(ProductDetailPage), typeof(ProductDetailPage));

        return builder.Build();
    }
}