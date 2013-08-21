using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleAnalyticsLinqProvider.Parsers.ExpressionParsers
{
    /// <summary>
    /// Conditional expression
    /// </summary>
    internal class ConditionalExpression : IExpression
    {
        /// <summary>
        /// The type of boolean operator (AND or OR)
        /// </summary>
        public BooleanOperator Operator { get; set; }

        /// <summary>
        /// Left operand of expression
        /// </summary>
        public IExpression Left { get; set; }

        /// <summary>
        /// Left operand of expression
        /// </summary>
        public IExpression Right { get; set; }

        /// <summary>
        /// Interface implementation. Parses expression to string
        /// </summary>
        /// <returns>String view of expression</returns>
        public string ParseToString()
        {
            return parseToString(Left.ParseToString(), Right.ParseToString());
        }

        /// <summary>
        /// Interface implementation. Parses inverted expression to string
        /// </summary>
        /// <returns>String view of inverted expression</returns>
        public string ParseInvertedToString()
        {
            return parseToString(Left.ParseInvertedToString(), Right.ParseInvertedToString());
        }

        /// <summary>
        /// Parses expression to string
        /// </summary>
        /// <param name="left">The string view of left operand's expression</param>
        /// <param name="right">The string view of right operand's expression</param>
        /// <returns>String</returns>
        private string parseToString(string left, string right)
        {
            string format = "{0}{1}{2}";
            string @operator;
            switch (Operator)
            {
                case BooleanOperator.And:
                    @operator = ";";
                    break;
                case BooleanOperator.Or:
                    @operator = ",";
                    break;
                default:
                    throw new Exception();
            }
            return string.Format(format, left, @operator, right);
        }
    }
}
