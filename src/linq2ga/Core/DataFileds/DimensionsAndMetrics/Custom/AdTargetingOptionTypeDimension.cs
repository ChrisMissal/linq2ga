using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linq2ga.Enums;

namespace linq2ga.Core.DataFields
{
    public class AdTargetingOptionTypeDimension : Dimension<AdTargetingOptionType>
    {
        internal override IFieldConverter<AdTargetingOptionType> FieldConverter
        {
            get
            {
                return new AdTargetingOptionTypeFieldConverter();
            }
        }
    }
}
