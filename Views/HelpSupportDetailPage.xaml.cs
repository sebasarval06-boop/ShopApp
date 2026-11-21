
using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class HelpSupportDetailPage : ContentPage, IQueryAttributable
{
    public HelpSupportDetailPage()
    {
        InitializeComponent();

        BindingContext = new HelpSupportDetailViewModel();
    }

    public void ApplyQueryAttributes(
        IDictionary<string, object> query)
    {
        if (query.TryGetValue("id", out var idObj)
            && idObj != null)
        {
            Title = $"Cliente: {idObj}";

            if (int.TryParse(idObj.ToString(), out int clientId))
            {
                if (BindingContext is HelpSupportDetailViewModel viewModel)
                {
                    // Asignar el cliente seleccionado
                    viewModel.ClientId = clientId;

                    // Recuperar compras guardadas en SQLite
                    viewModel.CargarCompras();
                }
            }
        }
    }
}
