using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleAnalyticsLinqProvider.Parsers;
using Google.Apis.Analytics.v3;
using System.Linq.Expressions;

namespace GoogleAnalyticsLinqProvider.Core
{
    /// <summary>
    /// Created Data context
    /// </summary>
    public class CreatedDataContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="queryData">Query data object</param>
        public CreatedDataContext(QueryData queryData)
        {
            _queryData = queryData;
        }

        /// <summary>
        /// Contains all necessary data for Google Analytics request
        /// </summary>
        private QueryData _queryData;

        /// <summary>
        /// Selects the data from Context Model and maps it to a Result object
        /// </summary>
        /// <typeparam name="T">The type of Result object</typeparam>
        /// <param name="expression">Lambda expression</param>
        /// <returns>Selected data context</returns>
        public SelectedDataContext<T> Select<T>(Expression<Func<ContextDataModel, T>> expression)
        {
            var selectResult = Factory.SelectExpressionParser.Parse(expression);
            _queryData.ResetMetricsAndDimensions();
            _queryData.Metrics.AddRange(selectResult.Metrics);
            _queryData.Dimensions.AddRange(selectResult.Dimensions);
            var selectedDataContext = new SelectedDataContext<T>(_queryData, selectResult.FieldsMap, expression.Compile());
            return selectedDataContext;
        }

        /// <summary>
        /// Filters the data by Context Model fields
        /// </summary>
        /// <param name="expression">Lambda expression</param>
        /// <returns>Created Data context</returns>
        public CreatedDataContext Where(Expression<Predicate<ContextDataModel>> expression)
        {
            _queryData.Filters.Add(Factory.FilterExpressionParser.Parse(expression));
            return this;
        }

        /// <summary>
        /// Filters the data by Segment ID
        /// </summary>
        /// <param name="segmentId">Segment ID</param>
        /// <returns>Created Data context</returns>
        public CreatedDataContext Segment(string segmentId)
        {
            _queryData.SegmentId = segmentId;
            return this;
        }

        /// <summary>
        /// Filters the data by Context Model fields (dynamic segmentation)
        /// </summary>
        /// <param name="expression">Lambda expression</param>
        /// <returns></returns>
        public CreatedDataContext Segment(Expression<Predicate<ContextDataModel>> expression)
        {
            _queryData.DynamicSegments.Add(Factory.FilterExpressionParser.Parse(expression));
            return this;
        }
    }
}
