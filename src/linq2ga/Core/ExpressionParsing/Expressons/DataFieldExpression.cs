using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linq2ga.Core;

namespace linq2ga.Parsers.ExpressionParsers
{
    /// <summary>
    /// Data field expression
    /// </summary>
    internal class DataFieldExpression: IExpression
    {
        /// <summary>
        /// 
        /// </summary>
        public ConditionalOperator Operator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DataFieldName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Type DataFieldType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Interface implementation. Parses expression to string
        /// </summary>
        /// <returns>String</returns>
        public string ParseToString()
        {
            return parseToString(false);
        }

        /// <summary>
        ///  Interface implementation. Parses inverted expression to string
        /// </summary>
        /// <returns>String</returns>
        public string ParseInvertedToString()
        {
            return parseToString(true);
        }

        /// <summary>
        /// Parses expression to string
        /// </summary>
        /// <param name="inverted">The flag indicating if the expression is inverted</param>
        /// <returns></returns>
        private string parseToString(bool inverted)
        {
            string format = "{0}{1}{2}";
            string @operator = null, value = null;
            BaseField baseField = (BaseField)Activator.CreateInstance(DataFieldType);
            baseField.SetValue(Value);
            value = baseField.GetStringValue();
            switch (Operator)
            {
                case ConditionalOperator.Equals:
                    @operator = inverted ? "!=" : "==";
                    break;
                case ConditionalOperator.NotEquals:
                    @operator = inverted ? "==" : "!=";
                    break;
                case ConditionalOperator.Greater:
                    @operator = inverted ? "<=" : ">";
                    break;
                case ConditionalOperator.Less:
                    @operator = inverted ? ">=" : "<";
                    break;
                case ConditionalOperator.EqualsOrGereater:
                    @operator = inverted ? "<" : ">=";
                    break;
                case ConditionalOperator.EqualsOrLess:
                    @operator = inverted ? ">" : "<=";
                    break;
                case ConditionalOperator.Contains:
                    @operator = inverted ? "!@" : "=@";
                    break;
                case ConditionalOperator.NotContains:
                    @operator = inverted ? "=@" : "!@";
                    break;
                case ConditionalOperator.Match:
                    @operator = inverted ? "!~" : "=~";
                    break;
                case ConditionalOperator.NotMatch:
                    @operator = inverted ? "=~" : "!~";
                    break;
                case ConditionalOperator.StartWith:
                    @operator = inverted ? "=~" : "=~";
                    value = "^" + value;
                    break;
                case ConditionalOperator.EndWith:
                    @operator = inverted ? "=~" : "=~";
                    value = value + "$";
                    break;
                default:
                    break;
            }
            string result = string.Format(format, Constants.GOOGLE_ANALYTICS_PREFIX + DataFieldName, @operator, value);
            return result;
        }
    }
}
