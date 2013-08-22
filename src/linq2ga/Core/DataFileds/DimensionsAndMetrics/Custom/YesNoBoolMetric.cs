using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace linq2ga.Core.DataFields
{
    public class YesNoBoolMetric : Metric<bool>
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
