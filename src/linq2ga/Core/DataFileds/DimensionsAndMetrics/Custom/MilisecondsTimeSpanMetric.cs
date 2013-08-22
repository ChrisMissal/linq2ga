using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace linq2ga.Core.DataFields
{
    public class MilisecondsTimeSpanMetric : Metric<TimeSpan>
    {
        internal override IFieldConverter<TimeSpan> FieldConverter
        {
            get
            {
                return new MilisecondsTimeSpanFieldConverter();
            }
        }
    }
}
