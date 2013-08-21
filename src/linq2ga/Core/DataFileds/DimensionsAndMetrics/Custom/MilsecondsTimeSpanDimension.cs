﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleAnalyticsLinqProvider.Core.DataFields
{
    public class MilisecondsTimeSpanDimension : Dimension<TimeSpan>
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
