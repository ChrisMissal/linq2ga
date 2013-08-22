using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linq2ga.Enums;

namespace linq2ga.Attributes
{
    /// <summary>
    /// Google Analytics field name attribute
    /// </summary>
    internal class FieldDataNameAttribute: Attribute
    {
        public FieldDataNameAttribute(string fieldName)
        {
            FieldName = fieldName;
        }
        public string FieldName { get; private set; }
    }
}
