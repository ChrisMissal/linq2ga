using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linq2ga.Parsers;
using Google.Apis.Analytics.v3.Data;
using System.Reflection;
using linq2ga.Enums;
using System.Linq.Expressions;
using Google.Apis.Analytics.v3;


namespace linq2ga.Core
{
    /// <summary>
    /// Selected data context
    /// </summary>
    /// <typeparam name="T">The type of Result object</typeparam>
    public class SelectedDataContext<T>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="queryData">Query data</param>
        /// <param name="filedsMap">The mapped set of Context model fields and Google Analytics fields</param>
        /// <param name="expression">Delegate which will be invoked to create the instance of the Result object</param>
        internal SelectedDataContext(QueryData queryData, FieldsMap filedsMap, Func<ContextDataModel, T> expression)
        {
            _expression = expression;
            _fieldsMap = filedsMap;
            _queryData = queryData;
        }

        #region private
        /// <summary>
        /// Query data
        /// </summary>
        private QueryData _queryData;

        /// <summary>
        /// The mapped set of Context model fields and Google Analytics fields
        /// </summary>
        private FieldsMap _fieldsMap;

        /// <summary>
        /// Delegate which will be invoked to create the instance of the Result object
        /// </summary>
        private Func<ContextDataModel, T> _expression;
        #endregion

        #region public
        /// <summary>
        /// Orders data by selected field
        /// </summary>
        /// <typeparam name="Tprop">Field type</typeparam>
        /// <param name="expression">Lambda expression</param>
        /// <returns>Selected data context</returns>
        public SelectedDataContext<T> OrderBy<Tprop>(Expression<Func<T, Tprop>> expression)
        {
            _queryData.SortingFields.Add(Factory.OrderByExpressionParser.Parse(expression, _fieldsMap));
            return this;
        }

        /// <summary>
        /// Orders data descending by selected field
        /// </summary>
        /// <typeparam name="Tprop">Selected data context</typeparam>
        /// <param name="expression">Lambda expression</param>
        /// <returns>Selected data context</returns>
        public SelectedDataContext<T> OrderByDesc<Tprop>(Expression<Func<T, Tprop>> expression)
        {
            _queryData.SortingFields.Add("-" + Factory.OrderByExpressionParser.Parse(expression, _fieldsMap));
            return this;
        }

        /// <summary>
        /// Returns the list of Result objects specified by expression in Select action
        /// </summary>
        /// <param name="skip">The count of skipped items</param>
        /// <param name="take">The count of taken items</param>
        /// <returns>List of Result objects</returns>
        public List<T> ToList(int? skip = null, int? take = null)
        {
            _queryData.Skip = skip;
            _queryData.Take = take;
            List<T> result = Factory.GetAnalyticsProcessor<T>().Execute(_queryData, _expression, _fieldsMap).ToList();
            _queryData.Reset();
            return result;
        }

        /// <summary>
        /// Returns the first element of the set of Result objects specified by expression in Select action
        /// </summary>
        /// <param name="skip">The quantity of skipped items</param>
        /// <returns>the first element of the set of result objects</returns>
        public T First(long? skip = null)
        {
            _queryData.Skip = skip;
            _queryData.Take = 1;
            T result = Factory.GetAnalyticsProcessor<T>().Execute(_queryData, _expression, _fieldsMap).FirstOrDefault();
            _queryData.Reset();
            return result;
        }

        /// <summary>
        /// Returns asynchronously the list of Result objects specified by expression in Select action 
        /// </summary>
        /// <param name="callback">Callbak with result data set which will be invoked when the process is executed</param>
        /// <param name="skip">The count of skipped items</param>
        /// <param name="take">The count of taken items</param>
        public void ToListAsync(Action<List<T>> callback, int? skip = null, int? take = null)
        {
            _queryData.Skip = skip;
            _queryData.Take = take;
            Factory.GetAnalyticsProcessor<T>().ExecuteAsync(_queryData, _expression, _fieldsMap, x =>
            {
                _queryData.Reset();
                callback(x.ToList());
            });
        }

        /// <summary>
        /// Returns asynchronously the first element of the list of Result objects specified by expression in Select action 
        /// </summary>
        /// <param name="callback">Callbak with result data set which will be invoked when the process is executed</param>
        /// <param name="skip">The count of skipped items</param>
        public void FirstAsync(Action<T> callback, long? skip = null)
        {
            _queryData.Skip = skip;
            _queryData.Take = 1;
            Factory.GetAnalyticsProcessor<T>().ExecuteAsync(_queryData, _expression, _fieldsMap, x =>
            {
                _queryData.Reset();
                callback(x.First());
            });
        }
        #endregion
    }
}
