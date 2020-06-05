using System;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XFTest.Models;
namespace XFTest.Converters
{
    class TotalTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int returnValue = 0;
            if (value != null && value is CleaningList cleaningList)
            {
                returnValue = cleaningList.TaskList.Sum(i => i.TimesInMinutes);
            }
            return returnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)value;
        }
    }
}
