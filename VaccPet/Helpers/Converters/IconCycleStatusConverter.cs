using System.Globalization;

namespace VaccPet.Helpers.Converters
{
    public class IconCycleStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string status = (string)value;

            if (status == "Completo") return ImageSource.FromFile("check_green.svg");

            return ImageSource.FromFile("pending_purple.svg");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
