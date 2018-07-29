using System;
using System.Windows.Data;

namespace Limitation.Converters
{
    public class ExpandTweetConverter : IMultiValueConverter
    {
        public object True  { get; set; }
        public object False { get; set; }

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)values[0])
                return this.True;

            for (int i = 1; i < values.Length; ++i)
                if (!(bool)values[i])
                    return this.False;

            return this.True;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
