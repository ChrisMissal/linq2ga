using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using linq2ga.Core;

namespace linq2ga.Parsers
{
    /// <summary>
    /// Generate a string for 'Filter' or 'Segment' parameters of Google Analytics query based on the lambda expression.
    /// </summary>
    internal interface IFilterExpressionParser
    {
        /// <summary>
        /// Returns string for 'Filter' or 'Segment' parameters of Google Analytics query by given lambda expression.
        /// </summary>
        /// <param name="expression">Lambda expression</param>
        /// <returns>String for 'Filter' parameter for Google Analytics query</returns>
        string Parse(Expression<Predicate<ContextDataModel>> expression);
    }
}
