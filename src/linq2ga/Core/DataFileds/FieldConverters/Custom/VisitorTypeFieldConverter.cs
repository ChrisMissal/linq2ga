using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleAnalyticsLinqProvider.Enums;

namespace GoogleAnalyticsLinqProvider.Core.DataFields
{
    internal class VisitorTypeFieldConverter : IFieldConverter<VisitorType>
    {
        const string NEW_VISITOR = "New Visitor";
        const string RETURNING_VISITOR = "Returning Visitor";

        public VisitorType GetValue(string value)
        {
            VisitorType result = 0;
            if (value == NEW_VISITOR)
            {
                result = VisitorType.NewVisitor;
            }
            else if (value == RETURNING_VISITOR)
            {
                result = VisitorType.ReturningVisitor;
            }
            return result;
        }

        public string GetStringValue(VisitorType value)
        {
            string result = null;
            if (value == VisitorType.NewVisitor)
            {
                result = NEW_VISITOR;
            }
            else if (value == VisitorType.ReturningVisitor)
            {
                result = RETURNING_VISITOR;
            }
            return result;
        }
    }
}
