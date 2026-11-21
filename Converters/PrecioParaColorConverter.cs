
using System.Globalization;
using Microsoft.Maui.Controls;

namespace ShopApp.Converters;

public class PrecioParaColorConverter : IValueConverter
{
    public object Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture)
    {
        if (value is decimal precio)
        {
            return precio > 1000
                ? Colors.Red
                : Colors.Green;
        }

        return Colors.Gray;
    }

    public object ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
