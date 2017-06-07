using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Globalization;
using PCalendar.Enums;

namespace PCalendar.Converters
{
    public class ThaiMonthYearConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime? date = value as DateTime?;
            if (!date.HasValue)
            {
                return null;
            }
            else
            {
                return $"{(ThaiMonthOfYear)date.Value.Month} {date.Value.Year + 543}";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
