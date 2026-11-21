using Microsoft.Extensions.DependencyInjection;
using ShopApp.Views;

namespace ShopApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Resolver la página mediante inyección de dependencias
        var helpSupportContent = this.FindByName<ShellContent>("HelpSupportContent");

        if (helpSupportContent != null)
        {
            helpSupportContent.ContentTemplate = new DataTemplate(
                () => IPlatformApplication.Current!
                    .Services
                    .GetRequiredService<HelpSupportPage>()
            );
        }

        Routing.RegisterRoute(nameof(CategoryPage), typeof(CategoryPage));
        Routing.RegisterRoute(nameof(ClientPage), typeof(ClientPage));
        Routing.RegisterRoute(nameof(ProductPage), typeof(ProductPage));
        Routing.RegisterRoute(nameof(HelpSupportDetailPage), typeof(HelpSupportDetailPage));
    }
}