using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleAnalyticsLinqProvider.Core
{
    /// <summary>
    /// Base abstract class for Context Model fields
    /// </summary>
    public abstract class BaseField
    {
        /// <summary>
        /// Sets value from given object
        /// </summary>
        /// <param name="value">Object value</param>
        internal abstract void SetValue(object value);

        /// <summary>
        /// Sets value from given string
        /// </summary>
        /// <param name="value">String value</param>
        internal abstract void SetValue(string value);

        /// <summary>
        /// Returns the value boxed to object
        /// </summary>
        /// <returns>Object value</returns>
        internal abstract object GetValue();

        /// <summary>
        /// Returns the string view of the value
        /// </summary>
        /// <returns>String value</returns>
        internal abstract string GetStringValue();
    }
}
