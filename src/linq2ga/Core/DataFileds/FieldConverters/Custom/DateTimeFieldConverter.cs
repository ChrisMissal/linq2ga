using System;

namespace linq2ga.Core.DataFields
{
    internal class DateTimeFieldConverter : IFieldConverter<DateTime>
    {
        public DateTime GetValue(string value)
        {
            int year = int.Parse(value.Substring(0, 4));
            int month = int.Parse(value.Substring(4, 2));
            int day = int.Parse(value.Substring(6, 2));
            return new DateTime(year, month, day);
        }

        public string GetStringValue(DateTime value)
        {
            return string.Format("{0:yyyy-MM-dd}", value);
        }
    }
}