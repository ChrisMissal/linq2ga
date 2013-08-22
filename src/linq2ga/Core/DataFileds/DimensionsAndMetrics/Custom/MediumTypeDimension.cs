using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linq2ga.Enums;

namespace linq2ga.Core.DataFields
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
