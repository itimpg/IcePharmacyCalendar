using PCalendar.Enums;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace PCalendar.Converters
{
    public class ThaiDateConverter : IValueConverter
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
                return $"{date.Value.Day} {(ThaiMonthOfYear)date.Value.Month} {date.Value.Year + 543}";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
