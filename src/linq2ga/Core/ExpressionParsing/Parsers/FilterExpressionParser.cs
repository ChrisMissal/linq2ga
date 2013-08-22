using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;

using linq2ga.Core;
using linq2ga.Attributes;
using linq2ga.Exceptions;
using linq2ga.Extensions;

namespace linq2ga.Parsers
{
    using Parsers = linq2ga.Parsers.ExpressionParsers;

    /// <summary>
    /// Generate a string for 'Filter' or 'Segment' parameters of Google Analytics query based on the lambda expression.
    /// </summary>
    internal class FilterExpressionParser : IFilterExpressionParser
    {
        #region public
        /// <summary>
        /// Interface implementaion. Returns string for 'Filter' or 'Segment' parameters of Google Analytics query by given lambda expression.
        /// </summary>
        /// <param name="expression">Lambda expression</param>
        /// <returns>String for 'Filter' parameter for Google Analytics query</returns>
        public string Parse(Expression<Predicate<ContextDataModel>> expression)
        {
            Parsers.IExpression rootExpression = getExpression(expression.Body);
            string result = rootExpression.ParseToString();
            return result;
        }
        #endregion

        #region private
        private Parsers.IExpression getExpression(Expression expression)
        {
            Parsers.IExpression exp;
            exp = parseBinaryExpression(expression);
            if (exp == null)
            {
                exp = parseUnaryExpression(expression);
                if (exp == null)
                {
                    exp = parseMemberExpression(expression);
                    if (exp == null)
                    {
                        throw new Exception();
                    }
                }
            }
            return exp;
        }

        private Parsers.IExpression parseBinaryExpression(Expression expression)
        {
            Parsers.IExpression result = null;
            BinaryExpression binaryExpression = expression as BinaryExpression;
            if (binaryExpression != null)
            {
                var nodeType = binaryExpression.NodeType;
                if (nodeType == ExpressionType.AndAlso || nodeType == ExpressionType.OrElse)
                {
                    var conditionExpression = new Parsers.ConditionalExpression();
                    conditionExpression.Left = getExpression(binaryExpression.Left);
                    conditionExpression.Right = getExpression(binaryExpression.Right);
                    switch (nodeType)
                    {
                        case ExpressionType.AndAlso:
                            conditionExpression.Operator = Parsers.BooleanOperator.And;
                            break;
                        case ExpressionType.OrElse:
                            conditionExpression.Operator = Parsers.BooleanOperator.Or;
                            break;
                    }
                    result = conditionExpression;
                }
                else
                {
                    Parsers.DataFieldExpression fieldExpression = null;
                    switch (nodeType)
                    {
                        case ExpressionType.Equal:
                            fieldExpression = createDataFieldExpression(Parsers.ConditionalOperator.Equals, binaryExpression);
                            break;
                        case ExpressionType.NotEqual:
                            fieldExpression = createDataFieldExpression(Parsers.ConditionalOperator.NotEquals, binaryExpression);
                            break;
                        case ExpressionType.LessThan:
                            fieldExpression = createDataFieldExpression(Parsers.ConditionalOperator.Less, binaryExpression);
                            break;
                        case ExpressionType.LessThanOrEqual:
                            fieldExpression = createDataFieldExpression(Parsers.ConditionalOperator.EqualsOrLess, binaryExpression);
                            break;
                        case ExpressionType.GreaterThan:
                            fieldExpression = createDataFieldExpression(Parsers.ConditionalOperator.Greater, binaryExpression);
                            break;
                        case ExpressionType.GreaterThanOrEqual:
                            fieldExpression = createDataFieldExpression(Parsers.ConditionalOperator.EqualsOrGereater, binaryExpression);
                            break;
                    }
                    result = fieldExpression;
                }
            }
            return result;
        }

        private Parsers.InvertExpression parseUnaryExpression(Expression expression)
        {
            Parsers.InvertExpression result = null;
            if (expression != null && expression is UnaryExpression)
            {
                var unaryExpression = expression as UnaryExpression;
                if (unaryExpression.NodeType == ExpressionType.Not)
                {
                    result = new Parsers.InvertExpression();
                    result.Expression = getExpression(unaryExpression.Operand);
                }
            }
            return result;
        }

        private Parsers.DataFieldExpression parseMemberExpression(Expression expression)
        {
            Parsers.DataFieldExpression result = null;
            if (expression is MethodCallExpression)
            {
                var methodCallExpression = expression as MethodCallExpression;
                if (methodCallExpression != null)
                {
                    switch (methodCallExpression.Method.Name)
                    {
                        case "Contains":
                            result = createDataFieldExpression(Parsers.ConditionalOperator.Contains, methodCallExpression);
                            break;
                        case "StartsWith":
                            result = createDataFieldExpression(Parsers.ConditionalOperator.StartWith, methodCallExpression);
                            break;
                        case "EndWith":
                            result = createDataFieldExpression(Parsers.ConditionalOperator.EndWith, methodCallExpression);
                            break;
                        case "Match":
                            result = createDataFieldExpression(Parsers.ConditionalOperator.Match, methodCallExpression);
                            break;
                    }
                }
            }
            return result;
        }

        private Parsers.DataFieldExpression createDataFieldExpression(Parsers.ConditionalOperator @operator, MethodCallExpression expression)
        {
            var result = new Parsers.DataFieldExpression() { Operator = @operator };
            Type type;
            object constant = null;
            string fieldName = getFieldName(expression.Object, out type);
            constant = getConstantValue(expression.Arguments.First());
            result.DataFieldType = type;
            result.DataFieldName = fieldName;
            result.Value = constant;
            return result;
        }

        private Parsers.DataFieldExpression createDataFieldExpression(Parsers.ConditionalOperator @operator, BinaryExpression expression)
        {
            var result = new Parsers.DataFieldExpression() { Operator = @operator };
            Type type;
            object constant = null;
            string fieldName = getFieldName(expression.Left, out type);
            if (fieldName == null)
            {
                fieldName = getFieldName(expression.Right, out type);
                constant = getConstantValue(expression.Left);
            }
            else
            {
                constant = getConstantValue(expression.Right);
            }
            result.DataFieldType = type;
            result.DataFieldName = fieldName;
            result.Value = constant;
            return result;
        }

        private string getFieldName(Expression exp, out Type type)
        {
            type = null;
            MemberExpression member = exp as MemberExpression;
            if (member != null)
            {
                string dataFieldName = member.Member.GetFieldDataNameAttributeValue();
                if (dataFieldName != null)
                {
                    type = (member.Member as PropertyInfo).PropertyType;
                    return dataFieldName;
                }
            }
            else
            {
                MethodCallExpression method = exp as MethodCallExpression;
                if (method != null)
                {
                    string dataFieldName = method.Method.GetFieldDataNameAttributeValue();
                    if (dataFieldName != null)
                    {
                        type = method.Method.ReturnType;
                        string[] arguments = method.Arguments.Select(x =>
                        {
                            object value = getConstantValue(x);
                            return value != null ? value.ToString() : string.Empty;
                        }).ToArray();
                        return string.Format(dataFieldName, arguments);
                    }
                }
                else
                {
                    UnaryExpression unary = exp as UnaryExpression;
                    if (unary != null)
                    {
                        return getFieldName(unary.Operand, out type);
                    }
                }
            }
            return null;
        }

        private object getConstantValue(Expression exp)
        {
            object result = null;
            switch (exp.NodeType)
            {
                case ExpressionType.Constant:
                    result = (exp as ConstantExpression).Value;
                    break;
                case ExpressionType.MemberAccess:
                    MemberExpression member = exp as MemberExpression;
                    string memberName = member.Member.Name;
                    ConstantExpression memberConstantExpression = member.Expression as ConstantExpression;
                    if (memberConstantExpression != null)
                    {
                        var field = memberConstantExpression.Value.GetType().GetField(memberName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                        result = field.GetValue(memberConstantExpression.Value);
                    }
                    else
                    {
                        //if static field or property
                        switch (member.Member.MemberType)
                        {
                            case MemberTypes.Field:
                                result = (member.Member as FieldInfo).GetValue(null);
                                break;
                            case MemberTypes.Property:
                                result = (member.Member as PropertyInfo).GetValue(null, null);
                                break;
                        }
                    }
                    break;
                case ExpressionType.UnaryPlus:
                    result = getConstantValue((exp as UnaryExpression).Operand);
                    break;
            }
            return result;
        }
        #endregion
    }
}
