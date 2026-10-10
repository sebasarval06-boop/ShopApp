using ShopApp.DataAcces; // <--- Cambiar 'DataAccess' por 'DataAcces' (una 's')

namespace ShopApp.Views;

public partial class ProductDetailPage : ContentPage, IQueryAttributable
{
    public ProductDetailPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("id"))
        {
            var id = int.Parse(query["id"].ToString());

            using var dbContext = new ShopDbContext();
            var producto = dbContext.Products.FirstOrDefault(x => x.Id == id);

            if (producto != null)
            {
                container.Children.Clear();
                container.Children.Add(new Label { Text = producto.Nombre, FontSize = 22 });
                container.Children.Add(new Label { Text = producto.Descripcion });
                container.Children.Add(new Label { Text = $"Precio: {producto.Precio}" });
            }
        }
    }
}