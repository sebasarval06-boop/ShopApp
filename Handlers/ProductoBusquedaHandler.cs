using ShopApp.DataAcces; // Nombre exacto de tu carpeta de datos en el explorador
using ShopApp.Views;

namespace ShopApp.Handlers;

public class ProductoBusquedaHandler : SearchHandler
{
    // Se ejecuta al escribir en la barra de búsqueda
    protected override void OnQueryChanged(string oldValue, string newValue)
    {
        base.OnQueryChanged(oldValue, newValue);

        if (string.IsNullOrWhiteSpace(newValue))
        {
            ItemsSource = null;
        }
        else
        {
            using var db = new ShopDbContext();
            ItemsSource = db.Products
                .Where(p => p.Nombre.ToLower().Contains(newValue.ToLower()))
                .ToList();
        }
    }

    // Se ejecuta al seleccionar un elemento del menú desplegable de búsqueda
    protected override async void OnItemSelected(object item)
    {
        base.OnItemSelected(item);

        // Hacemos el cast dinámico para acceder al Id del producto seleccionado
        dynamic producto = item;

        if (producto != null)
        {
            var uri = $"{nameof(ProductDetailPage)}?id={producto.Id}";
            await Shell.Current.GoToAsync(uri);
        }
    }
}