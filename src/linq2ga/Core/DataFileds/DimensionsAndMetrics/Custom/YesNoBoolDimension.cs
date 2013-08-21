using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleAnalyticsLinqProvider.Core.DataFields
{
    public class YesNoBoolDimension : Dimension<bool>
    {
        internal override IFieldConverter<bool> FieldConverter
        {
            get
            {
                return new YesNoBoolFieldConverter();
            }
        }
    }
}
