using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleAnalyticsLinqProvider.Parsers.ExpressionParsers
{
    /// <summary>
    /// Invert expression
    /// </summary>
    internal class InvertExpression: IExpression
    {
        /// <summary>
        /// Operand of invert expression
        /// </summary>
        public IExpression Expression { get; set; }

        /// <summary>
        ///  Interface implementation. Parses expression to string
        /// </summary>
        /// <returns>String</returns>
        public string ParseToString()
        {
            return Expression.ParseInvertedToString();
        }
        
        /// <summary>
        ///  Interface implementation. Parses inverted expression to string
        /// </summary>
        /// <returns>String</returns>
        public string ParseInvertedToString()
        {
            return Expression.ParseToString();
        }
    }
}
