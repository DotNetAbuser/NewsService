using System.Globalization;

namespace Client.Converters;

public class FirstNameToCharConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null || (string)value == string.Empty)
            return string.Empty;
        
        var str = value.ToString().ToUpper();
        var firstChar = str[0];
        return firstChar;
    }
    
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}