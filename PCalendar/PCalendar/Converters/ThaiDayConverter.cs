using PCalendar.Enums;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace PCalendar.Converters
{
    public class ThaiDayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime? date = value as DateTime?;
            if (!date.HasValue)
            {
                return string.Empty;
            }
            else
            {
                return ((ThaiDayOfWeek)((int)date.Value.DayOfWeek)).ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
