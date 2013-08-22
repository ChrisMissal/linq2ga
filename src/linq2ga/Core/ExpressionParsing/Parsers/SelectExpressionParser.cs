using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using linq2ga.Core;
using linq2ga.Enums;
using linq2ga.Attributes;
using System.Reflection;
using System.Web;
using linq2ga.Exceptions;
using linq2ga.Extensions;

namespace linq2ga.Parsers
{
    /// <summary>
    /// Generate an object with data for 'Metrics' and 'Dimensions' parameters of Google Analytics query based on the lambda expression.
    /// </summary>
    internal class SelectExpressionParser : ISelectExpressionParser
    {
        #region public
        /// <summary>
        /// Interface implementaion. Returns an object with data for 'Metrics' and 'Dimensions' parameters of Google Analytics query by given lambda expression.
        /// </summary>
        /// <typeparam name="Tprop">Lambda expression selected member type</typeparam>
        /// <param name="expression">Lambda expression</param>
        /// <returns>String for 'Metrics' and 'Dimensions' parameters of Google Analytics</returns>
        public SelectExpressionParserResult Parse<Tprop>(Expression<Func<ContextDataModel, Tprop>> expression)
        {
            var result = new SelectExpressionParserResult();
            result.FieldsMap = new FieldsMap();
            result.Dimensions = new List<string> ();
            result.Metrics = new List<string>();
            try
            {
                if (expression.Body is MemberInitExpression)
                {
                    MemberInitExpression memberInitExpression = expression.Body as MemberInitExpression;
                    foreach (MemberAssignment binding in memberInitExpression.Bindings.Where(x => x is MemberAssignment))
                    {
                        string newName = binding.Member.Name;
                        MemberInfo member;
                        string fieldName = parseMemberExpression(binding.Expression, out member);
                        fillMap(result, member, newName, Constants.GOOGLE_ANALYTICS_PREFIX + fieldName);
                    }
                }
                else if (expression.Body is NewExpression)
                {
                    NewExpression nex = expression.Body as NewExpression;
                    for (int i = 0; i < nex.Arguments.Count; i++)
                    {
                        MemberInfo member;
                        string fieldName = parseMemberExpression(nex.Arguments[i], out member);
                        fillMap(result, member, nex.Members[i].Name, Constants.GOOGLE_ANALYTICS_PREFIX + fieldName);
                    }
                }
                else
                {
                    MemberInfo member;
                    string fieldName = parseMemberExpression(expression.Body, out member);
                    fillMap(result, member, fieldName, Constants.GOOGLE_ANALYTICS_PREFIX + fieldName);
                }
            }
            catch (Exception ex)
            {
                throw new NotSupportedExpressionException(expression, "Invalid expression.", ex);
            }
            if (result.Metrics.Count == 0)
            {
                throw new NotSupportedExpressionException(expression, "No metrics are set.");
            }
            return result;
        }
        #endregion

        #region private
        private void fillMap(SelectExpressionParserResult result, MemberInfo member, string selectedObjectFieldName, string googleAnalyticsFieldName)
        {
            FieldsMapItem item = new FieldsMapItem() { ContextModelMember = member, ResultObjectMemberName = selectedObjectFieldName, ContextModelMemberName = googleAnalyticsFieldName };
            result.FieldsMap.Add(item);
            if (item.IsDimension)
            {
                result.Dimensions.Add(googleAnalyticsFieldName);
            }
            else if (item.IsMetric)
            {
                result.Metrics.Add(googleAnalyticsFieldName);
            }
        }

        private string parseMemberExpression(Expression expression, out MemberInfo member)
        {
            if (expression is MemberExpression)
            {
                member = (expression as MemberExpression).Member as PropertyInfo;
                return member.GetFieldDataNameAttributeValue();
            }
            else if (expression is MethodCallExpression)
            {
                var methodCallExpression = (expression as MethodCallExpression);
                member = (expression as MethodCallExpression).Method;
                string fieldName = member.GetFieldDataNameAttributeValue();
                fieldName = string.Format(fieldName, methodCallExpression.Arguments.Cast<ConstantExpression>().Select(x => x.Value).ToArray());
                return fieldName;
            }
            else if (expression is UnaryExpression)
            {
                return parseMemberExpression((expression as UnaryExpression).Operand, out member);
            }
            else throw new Exception();
        }
        #endregion
    }
}
