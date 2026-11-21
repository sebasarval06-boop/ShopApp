
namespace ShopApp.Services;

public class NavegacionService : INavegacionService
{
    public async Task NavegarAsync(string ruta)
    {
        await Shell.Current.GoToAsync(ruta);
    }
}
