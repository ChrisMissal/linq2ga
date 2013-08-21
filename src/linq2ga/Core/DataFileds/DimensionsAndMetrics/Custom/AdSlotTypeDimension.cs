using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleAnalyticsLinqProvider.Enums;

namespace GoogleAnalyticsLinqProvider.Core.DataFields
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
