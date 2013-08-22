using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace linq2ga.Core.DataFields
{
    public class DateTimeDimension : Dimension<DateTime>
    {
        internal override IFieldConverter<DateTime> FieldConverter
        {
            get
            {
                return new DateTimeFieldConverter();
            }
        }
    }
}
