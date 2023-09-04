using System.Globalization;

namespace VaccPet.Helpers.Converters
{
    public class CycleStatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string status = (string)value;

            if (status == "Completo") return Colors.YellowGreen;
           
            return Colors.DeepPink;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
