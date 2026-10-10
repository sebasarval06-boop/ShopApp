using ShopApp.Views;

namespace ShopApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(CategoryPage), typeof(CategoryPage));
        Routing.RegisterRoute(nameof(ClientPage), typeof(ClientPage));
        Routing.RegisterRoute(nameof(ProductPage), typeof(ProductPage)); 
    }
}