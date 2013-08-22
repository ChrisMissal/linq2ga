﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linq2ga.Enums;
using linq2ga.Enums;

namespace linq2ga.Core.DataFields
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
