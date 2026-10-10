using ShopApp.DataAcces; // <--- Cambiar 'DataAccess' por 'DataAcces' (una 's')

namespace ShopApp.Views;

public partial class ProductPage : ContentPage
{
    public ProductPage()
    {
        InitializeComponent();

        using var dbContext = new ShopDbContext();

        foreach (var product in dbContext.Products)
        {
            var boton = new Button { Text = product.Nombre };
            boton.Clicked += async (s, e) =>
            {
                var uri = $"{nameof(ProductDetailPage)}?id={product.Id}";
                await Shell.Current.GoToAsync(uri);
            };

            container.Children.Add(boton);
        }
    }
}