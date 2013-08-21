using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using GoogleAnalyticsLinqProvider.Core;

namespace GoogleAnalyticsLinqProvider.Parsers
{
    /// <summary>
    /// Generate an object with data for 'Metrics' and 'Dimensions' parameters of Google Analytics query based on the lambda expression.
    /// </summary>
    internal interface ISelectExpressionParser
    {
        /// <summary>
        /// Interface implementaion. Returns an object with data for 'Metrics' and 'Dimensions' parameters of Google Analytics query by given lambda expression.
        /// </summary>
        /// <typeparam name="Tprop">Lambda expression selected member type</typeparam>
        /// <param name="expression">Lambda expression</param>
        /// <returns>String for 'Metrics' and 'Dimensions' parameters of Google Analytics</returns>
        SelectExpressionParserResult Parse<T>(Expression<Func<ContextDataModel, T>> expression);
    }
}
