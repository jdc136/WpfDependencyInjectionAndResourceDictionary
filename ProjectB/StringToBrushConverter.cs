using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ProjectB
{
    public class StringToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush brush;

            if (value is string statusColorString)
            {
                try
                {
                    Color statusColor = (Color)ColorConverter.ConvertFromString(statusColorString);
                    brush = new SolidColorBrush(statusColor);
                }
                catch (FormatException)
                {
                    brush = Brushes.White;
                }
            }
            else
            {
                brush = Brushes.White;
            }

            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
