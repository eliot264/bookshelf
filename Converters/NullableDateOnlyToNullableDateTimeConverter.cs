using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Bookshelf.Converters
{
    [ValueConversion(typeof(DateTime?), typeof(DateOnly?))]
    public class NullableDateOnlyToNullableDateTimeConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateOnly? dateOnly = (DateOnly?)value;
            return dateOnly != null ? dateOnly.Value.ToDateTime(new TimeOnly()) : null;
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime? dateTime = (DateTime?)value;
            return dateTime != null ? DateOnly.FromDateTime(dateTime.Value) : null;
        }
    }
}
