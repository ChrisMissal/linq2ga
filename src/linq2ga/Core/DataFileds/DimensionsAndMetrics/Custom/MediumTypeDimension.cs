using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleAnalyticsLinqProvider.Enums;

namespace GoogleAnalyticsLinqProvider.Core.DataFields
{
    public class MediumTypeDimension : Dimension<MediumType>
    {
        internal override IFieldConverter<MediumType> FieldConverter
        {
            get
            {
                return new MediumTypeFieldConverter();
            }
        }
    }
}
