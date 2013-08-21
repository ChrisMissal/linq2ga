using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleAnalyticsLinqProvider.Enums;
using System.Reflection;
using GoogleAnalyticsLinqProvider.Attributes;

namespace GoogleAnalyticsLinqProvider
{
    /// <summary>
    /// MemberInfo extension methods
    /// </summary>
    internal static class MemberInfoExtensions
    {
        /// <summary>
        /// Returns the data type of target Member (PropertyInfo or MethodInfo)
        /// </summary>
        /// <param name="memberInfo">Member (PropertyInfo or MethodInfo)</param>
        /// <returns>Data type (Dimension or Metric)</returns>
        public static DataType GetDataTypeOfMember(this MemberInfo memberInfo)
        {
            Type type;
            PropertyInfo propertyInfo = memberInfo as PropertyInfo;
            if (propertyInfo != null)
            {
                type = propertyInfo.PropertyType;
            }
            else
            {
                MethodInfo methodInfo = memberInfo as MethodInfo;
                if (methodInfo != null)
                {
                    type = methodInfo.ReturnType;
                }
                else
                {
                    return 0;
                }
            }
            if (IsDimension(type))
            {
                return DataType.Dimension;
            }
            else
            {
                return DataType.Metric;
            }
        }

        /// <summary>
        /// Returns the value of FieldDataName attribute
        /// </summary>
        /// <param name="member">Member (PropertyInfo or MethodInfo)</param>
        /// <returns>Google analytics field name</returns>
        public static string GetFieldDataNameAttributeValue(this MemberInfo member)
        {
            FieldDataNameAttribute attribute = (FieldDataNameAttribute)member.GetCustomAttributes(typeof(FieldDataNameAttribute), false).FirstOrDefault();
            if (attribute != null)
            {
                return attribute.FieldName;
            }
            return null;
        }

        /// <summary>
        /// Returns true if the target type is Dimension
        /// </summary>
        /// <param name="type">Target type</param>
        /// <returns>Is Dimension</returns>
        public static bool IsDimension(this Type type)
        {
            while (type != null)
            {
                if (type.Name.StartsWith("Dimension"))
                {
                    return true;
                }
                type = type.BaseType;
            }
            return false;
        }

        /// <summary>
        /// Returns true if the target type is Metric
        /// </summary>
        /// <param name="type">Target type</param>
        /// <returns>Is Metric</returns>
        public static bool IsMetric(this Type type)
        {
            while (type != null)
            {
                if (type.Name.StartsWith("Metric"))
                {
                    return true;
                }
                type = type.BaseType;
            }
            return false;
        }
    }
}
