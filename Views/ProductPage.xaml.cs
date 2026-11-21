
using System.Linq;
using ShopApp.DataAcces;

namespace ShopApp.Views;

public partial class ProductPage : ContentPage
{
    public ProductPage()
    {
        InitializeComponent();

        // Cargar productos desde la base de datos
        using var dbContext = new ShopDbContext();

        var productos = dbContext.Products.ToList();

        // Mostrar productos en el CollectionView
        productosCollection.ItemsSource = productos;
    }

    // Evento al seleccionar un producto
    private async void ProductosCollection_SelectionChanged(
        object sender,
        SelectionChangedEventArgs e)
    {
        // Obtener el producto seleccionado
        if (e.CurrentSelection.FirstOrDefault()
            is not Product producto)
        {
            return;
        }

        // Limpiar selección para permitir
        // seleccionar nuevamente el mismo producto
        if (sender is CollectionView collection)
        {
            collection.SelectedItem = null;
        }

        // Navegar al detalle del producto
        var uri =
            $"{nameof(ProductDetailPage)}?id={producto.Id}";

        await Shell.Current.GoToAsync(uri);
    }
}
