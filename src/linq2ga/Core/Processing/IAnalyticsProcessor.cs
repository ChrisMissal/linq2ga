using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace linq2ga.Core
{
    /// <summary>
    /// Google Analytics query processor interface
    /// </summary>
    /// <typeparam name="T">Type of result object</typeparam>
    internal interface IAnalyticsProcessor<T>
    {
        /// <summary>
        /// Exceutes the process synchronously
        /// </summary>
        /// <param name="queryData">The data for the query building</param>
        /// <param name="expression">The compiled delegate for Select expression</param>
        /// <param name="fieldsMap"></param>
        /// <returns></returns>
        IEnumerable<T> Execute(QueryData queryData, Func<ContextDataModel, T> expression, FieldsMap fieldsMap);

        /// <summary>
        /// Exceutes the process asynchronously
        /// </summary>
        /// <param name="queryData">The data for the query building</param>
        /// <param name="expression">The compiled delegate for Select expression</param>
        /// <param name="fieldsMap"></param>
        /// <param name="callback">Action that will be executed when the response is obtained</param>
        void ExecuteAsync(QueryData queryData, Func<ContextDataModel, T> expression, FieldsMap fieldsMap, Action<IEnumerable<T>> callback);
    }
}
