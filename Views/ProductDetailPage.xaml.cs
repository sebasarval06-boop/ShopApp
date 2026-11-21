using ShopApp.DataAcces;

namespace ShopApp.Views;

public partial class ProductDetailPage : ContentPage, IQueryAttributable
{
    public ProductDetailPage()
    {
        InitializeComponent();
    }


    public void ApplyQueryAttributes(
        IDictionary<string, object> query)
    {
        // Verificar que recibimos un ID válido
        if (!query.TryGetValue("id", out var idObj) ||
            !int.TryParse(idObj?.ToString(), out int id))
        {
            return;
        }

        // Buscar el producto por su ID
        using var dbContext = new ShopDbContext();

        var producto = dbContext.Products
            .FirstOrDefault(x => x.Id == id);

        if (producto != null)
        {
            // Limpiar el contenido anterior
            container.Children.Clear();

            // Mostrar los datos del producto
            container.Children.Add(
                new Label
                {
                    Text = producto.Nombre,
                    FontSize = 22
                });

            container.Children.Add(
                new Label
                {
                    Text = producto.Descripcion
                });

            container.Children.Add(
                new Label
                {
                    Text = $"Precio: {producto.Precio}"
                });
        }
    }

}