using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linq2ga.Parsers;

namespace linq2ga.Core
{
    /// <summary>
    /// A simple static factory that provides the instances for target interfaces
    /// </summary>
    internal static class Factory
    {
        /// <summary>
        /// Returns the instance for Filter expression parser
        /// </summary>
        public static IFilterExpressionParser FilterExpressionParser
        {
            get
            {
                return new FilterExpressionParser();
            }
        }

        /// <summary>
        /// Returns the instance for Segment expression parser
        /// </summary>
        public static IFilterExpressionParser SegmentExpressionParser
        {
            get
            {
                return new FilterExpressionParser();
            }
        }

        /// <summary>
        /// Returns the instance for Select expression parser
        /// </summary>
        public static ISelectExpressionParser SelectExpressionParser
        {
            get
            {
                return new SelectExpressionParser();
            }
        }

        /// <summary>
        /// Returns the instance for Sort expression parser
        /// </summary>
        public static IOrderByExpressionParser OrderByExpressionParser
        {
            get
            {
                return new OrderByExpressionParser();
            }
        }

        /// <summary>
        /// Returns the instance for Analytics processor
        /// </summary>
        /// <typeparam name="T">The type of Result Object</typeparam>
        /// <returns></returns>
        public static IAnalyticsProcessor<T> GetAnalyticsProcessor<T>()
        {
            return new AnalyticsProcessor<T>();
        }
    }
}
