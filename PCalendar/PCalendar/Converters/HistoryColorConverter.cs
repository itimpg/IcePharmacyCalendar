using System;
using System.Globalization;
using Xamarin.Forms;

namespace PCalendar.Converters
{
    class HistoryColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime? date = value as DateTime?;
            if (date.HasValue && date.Value.Date < DateTime.Today)
            {
                return Color.Silver;
            }
            return Color.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
