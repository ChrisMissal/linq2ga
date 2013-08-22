using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linq2ga.Enums;

namespace linq2ga.Core.DataFields
{
    public class AdSlotTypeDimension : Dimension<AdSlotType>
    {
        internal override IFieldConverter<AdSlotType> FieldConverter
        {
            get
            {
                return new AdSlotTypeFieldConverter();
            }
        }
    }
}
