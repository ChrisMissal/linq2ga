using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleAnalyticsLinqProvider.Core
{
    /// <summary>
    /// Provides the instance of Metric data field
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Metric<T> : BaseField<T>
    {
        /// <summary>
        /// Allows conversions between T type and  Metric<T> type inside lambda expressions
        /// </summary>
        /// <param name="arg">The value data type</param>
        /// <returns>Metric</returns>
        public static explicit operator Metric<T>(T arg)
        {
            return new Metric<T>() { Value = arg };
        }
    }
}
