using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Bookshelf.Converters
{
    [ValueConversion(typeof(ICollection), typeof(string))]
    public class ObjectListToStringListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StringBuilder result = new StringBuilder();
            IList list = (IList)value;

            if (list == null)
            {
                result.Append("List is null");
                return result;
            }

            if(list.Count == 0)
            {
                result.Append("Empty");
                return result;
            }

            for(int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                {
                    result.Append(list[i].ToString());
                }
                else
                {
                    result.Append("null");
                }

                if(i < list.Count - 1)
                {
                    result.Append(", ");
                }
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
