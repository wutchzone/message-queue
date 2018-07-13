using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace message_queue.Base.View
{
    class EmoteURLToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<string> _value = value as List<string>;
            List<Image> _newValue = new List<Image>();

            foreach (var item in _value)
            {
                Image _image = new Image();
                BitmapImage _bitmap = new BitmapImage();
                _bitmap.BeginInit();
                _bitmap.UriSource = new Uri(item, UriKind.Absolute);
                _bitmap.EndInit();
                _image.Width = 28;
                _image.Height = 28;
                _image.Stretch = Stretch.Fill;
                _image.Source = _bitmap;

                _newValue.Add(_image);
            }
            return _newValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
