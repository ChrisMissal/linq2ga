using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleAnalyticsLinqProvider.Core.DataFields
{
    public class SecondsTimeSpanMetric : Metric<TimeSpan>
    {
        internal override IFieldConverter<TimeSpan> FieldConverter
        {
            get
            {
                return new SecondsTimeSpanFieldConverter();
            }
        }
    }
}
