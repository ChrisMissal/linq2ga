using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleAnalyticsLinqProvider.Core.DataFields
{
    internal class DayOfWeekFieldConverter : IFieldConverter<DayOfWeek>
    {
        public DayOfWeek GetValue(string value)
        {
            int num = int.Parse(value);
            return (DayOfWeek)num;
        }

        public string GetStringValue(DayOfWeek value)
        {
            return ((int)value).ToString();
        }
    }
}
