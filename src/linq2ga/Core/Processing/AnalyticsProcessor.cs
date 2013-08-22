using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Analytics.v3.Data;
using Google.Apis.Analytics.v3;
using System.Reflection;
using linq2ga.Enums;
using linq2ga.Exceptions;
using linq2ga.Extensions;

namespace linq2ga.Core
{
    internal class AnalyticsProcessor<T> : IAnalyticsProcessor<T>
    {
        #region public
        public IEnumerable<T> Execute(QueryData queryData, Func<ContextDataModel, T> expression, FieldsMap fieldsMap)
        {
            var request = getRequest(queryData);
            try
            {
                GaData data = request.Fetch();
                return getResult(data, expression, fieldsMap);
            }
            catch (Exception ex)
            {
                var requestExceprion = new GoogleAnalyticsRequestException("Can't fetch data", ex);
                throw requestExceprion;
            }
        }

        public void ExecuteAsync(QueryData queryData, Func<ContextDataModel, T> expression, FieldsMap fieldsMap, Action<IEnumerable<T>> callback)
        {
            var request = getRequest(queryData);
            request.FetchAsync(lazyData =>
            {
                try
                {
                    GaData data = lazyData.GetResult();
                    callback(getResult(data, expression, fieldsMap));
                }
                catch (Exception ex)
                {
                    var requestExceprion = new GoogleAnalyticsRequestException("Can't fetch data", ex);
                    throw requestExceprion;
                }
            });
        }
        #endregion

        #region private
        private Google.Apis.Analytics.v3.DataResource.GaResource.GetRequest getRequest(QueryData queryData)
        {
            string metrics = string.Join(",", queryData.Metrics);
            string dimensions = string.Join(",", queryData.Dimensions);
            string sort = string.Join(",", queryData.SortingFields);
            string filter = string.Join(";", queryData.Filters);
            string segment = null;
            if (queryData.SegmentId != null)
            {
                segment = "gaid::" + queryData.SegmentId;
            }
            else
            {
                segment = string.Join(";", queryData.DynamicSegments);
            }
            try
            {
                var request = queryData.Service.Data.Ga.Get(queryData.ProfileId, queryData.From.ToString("yyyy-MM-dd"), queryData.To.ToString("yyyy-MM-dd"), metrics);
                request.Dimensions = dimensions;
                request.Sort = sort;
                request.Filters = filter;
                request.StartIndex = queryData.Skip;
                request.MaxResults = queryData.Take;
                request.Segment = segment;
                return request;
            }
            catch (Exception ex)
            {
                var requestExceprion = new GoogleAnalyticsRequestException("Can't get request", ex);
                throw requestExceprion;
            }
        }

        private IEnumerable<T> getResult(GaData data, Func<ContextDataModel, T> expression, FieldsMap fieldsMap)
        {
            var contextProperties = new Dictionary<string, PropertyInfo>();
            ContextDataModel context = new ContextDataModel();
            Type contextType = typeof(ContextDataModel);
            if (data.Rows != null)
            {
                foreach (var row in data.Rows)
                {
                    for (int i = 0; i < data.ColumnHeaders.Count; i++)
                    {
                        string fieldName = data.ColumnHeaders[i].Name;
                        var item = fieldsMap.FindByContextModelFieldName(fieldName);
                        MemberInfo member = item.ContextModelMember;
                        if (item.IsProperty)
                        {
                            PropertyInfo propertyInfo = member as PropertyInfo;
                            DataType dataType = propertyInfo.GetDataTypeOfMember();
                            BaseField field = (BaseField)Activator.CreateInstance(propertyInfo.PropertyType);
                            string fieldValue = row[i];
                            field.SetValue(fieldValue);
                            propertyInfo.SetValue(context, field, null);
                        }
                        else if (item.IsMethod)
                        {
                            MethodInfo methodInfo = member as MethodInfo;
                            MethodInfo setter = contextType.GetMethod("addTofieldsForMethodStorage", BindingFlags.NonPublic | BindingFlags.Instance);
                            BaseField field = (BaseField)Activator.CreateInstance(methodInfo.ReturnType);
                            setter.Invoke(context, new object[] { fieldName, field });
                        }
                    }
                    T res = expression(context);
                    yield return res;
                }
            }
        }
        #endregion
    }
}
