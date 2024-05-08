using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Ejemplo1.Converters
{
    public class StatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo ulture)
        {
            return (bool)value ?
            (Color)Application.Current.Resources[
            "CompletedColor"] :
            (Color)Application.Current.Resources[
            "ActiveColor"];
        }
        public object ConvertBack(object value, Type
            targetType,
            object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
