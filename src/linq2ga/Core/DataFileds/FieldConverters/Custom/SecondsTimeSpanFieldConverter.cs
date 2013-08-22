using System;

namespace linq2ga.Core.DataFields
{
    internal class SecondsTimeSpanFieldConverter : IFieldConverter<TimeSpan>
    {
        public TimeSpan GetValue(string value)
        {
            int seconds = int.Parse(value);
            return TimeSpan.FromSeconds(seconds);
        }

        public string GetStringValue(TimeSpan value)
        {
            return value.TotalSeconds.ToString();
        }
    }
}
