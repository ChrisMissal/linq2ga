using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using GoogleAnalyticsLinqProvider.Enums;

namespace GoogleAnalyticsLinqProvider.Core
{
    /// <summary>
    /// Provides the relation between the Result Object member and Context Model member in the Select clause
    /// </summary>
    internal class FieldsMapItem
    {
        #region properties
        /// <summary>
        /// Context model member
        /// </summary>
        public MemberInfo ContextModelMember { get; set; }

        /// <summary>
        /// The name of Result Object member
        /// </summary>
        public string ResultObjectMemberName { get; set; }

        /// <summary>
        /// The name of Context Model member
        /// </summary>
        public string ContextModelMemberName { get; set; }

        #endregion

        #region methods
        /// <summary>
        /// The type of Google Analytics data field (metric or dimension)
        /// </summary>
        public DataType Datatype
        {
            get
            {
                return ContextModelMember.GetDataTypeOfMember();
            }
        }

        /// <summary>
        /// Returns true if Google Analytics data field is a metric
        /// </summary>
        public bool IsMetric
        {
            get
            {
                return Datatype == DataType.Metric;
            }
        }

        /// <summary>
        /// Returns true if Google Analytics data field is a dimension
        /// </summary>
        public bool IsDimension
        {
            get
            {
                return Datatype == DataType.Dimension;
            }
        }

        /// <summary>
        /// Returns true if the member of Context Model instance is a method
        /// </summary>
        public bool IsMethod
        {
            get
            {
                return ContextModelMember is MethodInfo;
            }
        }

        /// <summary>
        /// Returns true if the member of Context Model instance is a property
        /// </summary>
        public bool IsProperty
        {
            get
            {
                return ContextModelMember is PropertyInfo;
            }
        }
        #endregion
    }
}
