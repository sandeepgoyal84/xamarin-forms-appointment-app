using System;
using System.Globalization;
using Xamarin.Forms;
using XFTest.Models;

namespace XFTest.Converters
{
    internal class StartTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string returnValue = string.Empty;
            if (value != null && value is CleaningList cleaningList)
            {
                returnValue = string.IsNullOrEmpty(cleaningList.ExpectedTime) ? 
                    string.Format("{0}", cleaningList.StartTimeUtc.ToString("hh:mm")) 
                    : string.Format("{0}/{1}", cleaningList.StartTimeUtc.ToString("hh:mm"), cleaningList.ExpectedTime.Replace("/", "-"));
            }
            return returnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)value;
        }
    }
}