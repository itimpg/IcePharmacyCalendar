﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace PCalendar.Converters
{
    public class DayColorConverter : IValueConverter
    {
        Color[] ColorOfWeek = new Color[]
        {
            Color.Salmon,
            Color.Gold,
            Color.Orchid,
            Color.LightSeaGreen,
            Color.DarkOrange,
            Color.CornflowerBlue,
            Color.MediumPurple
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime? date = value as DateTime?;
            if (date.HasValue)
            {
                return ColorOfWeek[(int)date.Value.DayOfWeek];
            }
            return Color.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
