using message_queue.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.Windows.Controls;

namespace message_queue.Base.View
{
    class PaginationConvertor : IMultiValueConverter
    {
        private int numberOfElementsPerPage = 22;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            List<Message> _newValue = new List<Message>();
            List<Message> _value = values[0] as List<Message>;
            int _parameter = int.Parse(values[1].ToString());

            for (int i = (_parameter * numberOfElementsPerPage) - numberOfElementsPerPage; i < _parameter * numberOfElementsPerPage; i++)
            {
                if(i < _value.Count && i >= 0)
                {
                    _newValue.Add(_value[i]);
                }
            }

            return _newValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
