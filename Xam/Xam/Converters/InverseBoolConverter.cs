using System;
using Xamarin.Forms;

namespace Xam.Converters
{
    /// <summary>
    /// Inverts a boolean value
    /// </summary>
    public class InverseBoolConverter : IValueConverter
    {
        /// <summary>
		/// Converts a boolean to it's negated value/>.
		/// </summary>
		/// <param name="value">The boolean to negate.</param>
		/// <param name="targetType">not used.</param>
		/// <param name="parameter">not used.</param>
		/// <param name="culture">not used.</param>
		/// <returns>Negated boolean value.</returns>
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !((bool)value);
        }

        /// <summary>
        /// Converts a negated value back to it's non negated value.
        /// </summary>
        /// <param name="value">The value to be un negated.</param>
        /// <param name="targetType">not used.</param>
        /// <param name="parameter">not used.</param>
        /// <param name="culture">not used.</param>
        /// <returns>The original unnegated value.</returns>      
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !((bool)value);
        }
    }
}
