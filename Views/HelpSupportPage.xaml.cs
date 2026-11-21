
using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class HelpSupportPage : ContentPage
{
    public HelpSupportPage(HelpSupportViewModel viewModel)
    {
        InitializeComponent();

        // Conectar la página con el ViewModel recibido
        BindingContext = viewModel;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is HelpSupportViewModel viewModel)
        {
            viewModel.VisitasPendientes = 30;
        }
    }

    private async void OnVerDetalleClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(
            nameof(HelpSupportDetailPage),
            new Dictionary<string, object>
            {
                { "id", 1 }
            });
    }
}
