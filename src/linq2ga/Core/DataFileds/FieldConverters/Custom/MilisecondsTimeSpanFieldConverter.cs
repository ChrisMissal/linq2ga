using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleAnalyticsLinqProvider.Core.DataFields
{
    internal class MilisecondsTimeSpanFieldConverter : IFieldConverter<TimeSpan>
    {
        public TimeSpan GetValue(string value)
        {
            int miliseconds = int.Parse(value);
            return TimeSpan.FromMilliseconds(miliseconds);
        }

        public string GetStringValue(TimeSpan value)
        {
            return value.TotalMilliseconds.ToString();
        }
    }
}
