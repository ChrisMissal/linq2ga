using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleAnalyticsLinqProvider.Enums;

namespace GoogleAnalyticsLinqProvider.Core.DataFields
{
    public class VisitorTypeDimension : Dimension<VisitorType>
    {
        internal override IFieldConverter<VisitorType> FieldConverter
        {
            get
            {
                return new VisitorTypeFieldConverter();
            }
        }
    }
}
