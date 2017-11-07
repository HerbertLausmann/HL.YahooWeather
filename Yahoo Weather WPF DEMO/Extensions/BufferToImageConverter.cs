using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Yahoo_Weather_WPF_DEMO
{
    class BufferToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return value;
            if (value.GetType() == typeof(byte[]))
            {
                System.IO.MemoryStream mem = new System.IO.MemoryStream(value as byte[]);
                return BitmapFrame.Create(mem);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return value;
            if (value.GetType() == typeof(byte[]))
            {
                System.IO.MemoryStream mem = new System.IO.MemoryStream(value as byte[]);
                return BitmapFrame.Create(mem);
            }
            return null;
        }
    }
}
