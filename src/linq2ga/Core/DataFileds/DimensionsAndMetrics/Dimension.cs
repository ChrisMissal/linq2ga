using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace linq2ga.Core
{
    /// <summary>
    /// Provides the instance of Dimension data field
    /// </summary>
    /// <typeparam name="T">The value data type</typeparam>
    public class Dimension<T> : BaseField<T>
    {
        /// <summary>
        /// Allows conversions between T type and  Dimension<T> type inside lambda expressions
        /// </summary>
        /// <param name="arg">The value data type</param>
        /// <returns>Dimension</returns>
        public static explicit operator Dimension<T>(T arg)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Aggregate metrics where the dimension contains given substring
        /// </summary>
        /// <param name="substr">Given substring</param>
        /// <returns>Boolean</returns>
        public bool Contains(string substr)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Aggregate metrics where the dimension matches to given regular expression
        /// </summary>
        /// <param name="substr"></param>
        /// <returns>Boolean</returns>
        public bool Match(string exp)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Aggregate metrics where the dimension starts with given substring
        /// </summary>
        /// <param name="substr"></param>
        /// <returns>Boolean</returns>
        public bool StartsWith(string substr)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Aggregate metrics where the dimension ends with given substring
        /// </summary>
        /// <param name="substr"></param>
        /// <returns>Boolean</returns>
        public bool EndWith(string substr)
        {
            throw new NotImplementedException();
        }
    }
}
