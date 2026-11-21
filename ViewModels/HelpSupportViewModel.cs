
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.DataAcces;
using ShopApp.Services;
using ShopApp.Views;

namespace ShopApp.ViewModels;

public class HelpSupportViewModel : ObservableObject
{
    // Servicio de navegación
    private readonly INavegacionService _navegacionService;

    // VISITAS PENDIENTES
    private int _visitasPendientes;

    public int VisitasPendientes
    {
        get => _visitasPendientes;
        set => SetProperty(ref _visitasPendientes, value);
    }

    // LISTA DE CLIENTES
    private ObservableCollection<Client> _clients = new();

    public ObservableCollection<Client> Clients
    {
        get => _clients;
        set => SetProperty(ref _clients, value);
    }

    // CLIENTE SELECCIONADO
    private Client? _clienteSeleccionado;

    public Client? ClienteSeleccionado
    {
        get => _clienteSeleccionado;
        set
        {
            if (SetProperty(ref _clienteSeleccionado, value)
                && value != null)
            {
                _ = NavegarAlClienteAsync(value.Id);
            }
        }
    }

    // CONSTRUCTOR
    public HelpSupportViewModel(
        INavegacionService navegacionService)
    {
        _navegacionService = navegacionService;

        // Cargar clientes desde la base de datos
        using var database = new ShopDbContext();

        Clients = new ObservableCollection<Client>(
            database.Clients.ToList()
        );
    }

    // NAVEGAR AL DETALLE DEL CLIENTE
    private async Task NavegarAlClienteAsync(int clienteId)
    {
        var ruta =
            $"{nameof(HelpSupportDetailPage)}?id={clienteId}";

        await _navegacionService.NavegarAsync(ruta);
    }
}
