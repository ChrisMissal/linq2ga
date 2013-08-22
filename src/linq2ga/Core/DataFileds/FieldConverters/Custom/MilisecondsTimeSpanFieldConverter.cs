using System;

namespace linq2ga.Core.DataFields
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
