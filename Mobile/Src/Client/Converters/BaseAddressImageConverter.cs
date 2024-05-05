using System.Globalization;

namespace Client.Converters;

public class BaseAddressImageConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var serverFilePath = value.ToString();
        if (string.IsNullOrWhiteSpace(serverFilePath))
            return string.Empty;
        var uri = ApplicationConstants.BaseAddress + serverFilePath;
        return uri;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}