﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace linq2ga.Core.DataFields
{
    public class DayOfWeekDimension : Dimension<DayOfWeek>
    {
        internal override IFieldConverter<DayOfWeek> FieldConverter
        {
            get
            {
                return new DayOfWeekFieldConverter();
            }
        }
    }
}
