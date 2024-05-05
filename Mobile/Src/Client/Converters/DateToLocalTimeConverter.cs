using System.Globalization;

namespace Client.Converters;

public class DateToLocalTimeConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null)
            return string.Empty;

        var datetime = (DateTime)value;
        //put your custom formatting here
        return datetime.ToLocalTime().ToString("dd MMMM yyyy HH:mm");

    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}