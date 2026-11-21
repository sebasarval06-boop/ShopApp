
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopApp.DataAcces;

namespace ShopApp.ViewModels;

public class HelpSupportDetailViewModel : ObservableObject
{
    // LISTA DE PRODUCTOS
    private ObservableCollection<Product> _products = new();

    public ObservableCollection<Product> Products
    {
        get => _products;
        set => SetProperty(ref _products, value);
    }

    // PRODUCTO SELECCIONADO
    private Product? _productoSeleccionado;

    public Product? ProductoSeleccionado
    {
        get => _productoSeleccionado;
        set => SetProperty(ref _productoSeleccionado, value);
    }

    // CANTIDAD DE PRODUCTOS
    private double _cantidad = 1;

    public double Cantidad
    {
        get => _cantidad;
        set => SetProperty(ref _cantidad, value);
    }

    // ID DEL CLIENTE
    private int _clientId;

    public int ClientId
    {
        get => _clientId;
        set => SetProperty(ref _clientId, value);
    }

    // COMPRAS REGISTRADAS
    public ObservableCollection<Compra> Compras { get; }
        = new ObservableCollection<Compra>();

    // COMANDO PARA AGREGAR COMPRAS
    public ICommand AddCommand { get; }

    // CONSTRUCTOR

    public HelpSupportDetailViewModel()
    {
        AddCommand = new MiComando(AgregarCompra);

        using var db = new ShopDbContext();

        // Cargar productos desde SQLite
        Products = new ObservableCollection<Product>(
            db.Products.ToList()
        );
    }


    public void CargarCompras()
    {
        Compras.Clear();

        using var db = new ShopDbContext();

        var comprasGuardadas = db.Compras
            .Where(c => c.ClientId == ClientId)
            .OrderByDescending(c => c.Fecha)
            .ToList();

        foreach (var compra in comprasGuardadas)
        {
            Compras.Add(compra);
        }
    }


    // REGISTRAR COMPRA
    private void AgregarCompra()
    {
        // Validar que se haya seleccionado un producto
        if (ProductoSeleccionado == null)
        {
            return;
        }

        // Obtener cantidad
        int cantidad = (int)Cantidad;

        if (cantidad < 1)
        {
            return;
        }

        // Crear la compra
        var compra = new Compra
        {
            ClientId = ClientId,
            ProductId = ProductoSeleccionado.Id,
            Cantidad = cantidad,
            PrecioUnitario = ProductoSeleccionado.Precio,
            Total = ProductoSeleccionado.Precio * cantidad,
            Fecha = DateTime.Now
        };

        // Guardar en la base de datos
        using var db = new ShopDbContext();

        db.Compras.Add(compra);
        db.SaveChanges();

        // Actualizar la lista en pantalla
        Compras.Add(compra);
    }
}
