namespace ShopApp.Views;

public partial class CategoryPage : ContentPage
{
    public CategoryPage()
    {
        InitializeComponent();
    }

    private async void OnClientesClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("ClientPage");
    }

    private async void OnProductosClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("ProductPage");
    }
}