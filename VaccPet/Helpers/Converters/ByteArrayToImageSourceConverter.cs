using System.Globalization;

namespace VaccPet.Helpers.Converters;

public class ByteArrayToImageSourceConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is byte[] imageData)
        {
            return ImageSource.FromStream(() => new MemoryStream(imageData));
        }

        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
