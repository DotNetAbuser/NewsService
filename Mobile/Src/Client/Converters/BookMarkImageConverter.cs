using System.Globalization;

namespace Client.Converters;

public class BookMarkImageConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var isBookMarked = (bool)value;
        return isBookMarked ? "bookmark_filled.svg" : "bookmark.svg";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}