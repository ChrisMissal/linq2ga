using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleAnalyticsLinqProvider.Parsers.ExpressionParsers
{
    /// <summary>
    /// Expression parser interface
    /// </summary>
    internal interface IExpression
    {
        /// <summary>
        /// Parse expression to string
        /// </summary>
        /// <returns>String view of expression</returns>
        string ParseToString();

        /// <summary>
        /// Parse inverted expression to string
        /// </summary>
        /// <returns>String view of inverted expression</returns>
        string ParseInvertedToString();
    }
}
