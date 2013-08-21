using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using GoogleAnalyticsLinqProvider.Core;

namespace GoogleAnalyticsLinqProvider.Parsers
{
    /// <summary>
    /// Generate a string for 'Sort' parameter of Google Analytics query based on the lambda expression.
    /// </summary>
    internal class OrderByExpressionParser : IOrderByExpressionParser
    {
        /// <summary>
        /// Returns a string for 'Sort' parameter of Google Analytics query based on given lambda expression
        /// </summary>
        /// <typeparam name="T">Result object data type</typeparam>
        /// <typeparam name="Tprop">Target field data type</typeparam>
        /// <param name="expression">Lambda expression</param>
        /// <param name="fieldsMap">The mapped set of Context model fields and Google Analytics fields</param>
        /// <returns>String</returns>
        public string Parse<T, Tprop>(Expression<Func<T, Tprop>> expression, FieldsMap fieldsMap)
        {
            string result = null;
            MemberExpression memberExpression = expression.Body as MemberExpression;
            if (memberExpression != null)
            {
                string propertyName = memberExpression.Member.Name;
                result = fieldsMap.FindByResultObjectFieldName(propertyName).ContextModelMemberName;
            }
            return result;
        }
    }
}
