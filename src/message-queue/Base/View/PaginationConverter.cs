using message_queue.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace message_queue.Base.View
{
    class PaginationConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            List<Message> _newValue = new List<Message>();
            List<Message> _value = values[0] as List<Message>;
            int numberOfElementsPerPage = int.Parse(parameter.ToString());
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
