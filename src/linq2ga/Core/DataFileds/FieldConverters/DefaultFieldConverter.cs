using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace linq2ga.Core
{
    internal class DefaultFieldConverter<T> : IFieldConverter<T>
    {
        public T GetValue(string value)
        {
           return (T)Convert.ChangeType(value, typeof(T));
        }

        public string GetStringValue(T value)
        {
            var converters = new Dictionary<Type, Func<T, string>>();
            Func<T, string> decimalConverter = (x) =>
            {
                return ((double)(object)x).ToString(new CultureInfo("en-US"));
            };
            converters.Add(typeof(float), decimalConverter);
            converters.Add(typeof(decimal), decimalConverter);
            converters.Add(typeof(double), decimalConverter);
            if (converters.ContainsKey(typeof(T)))
            {
                return converters[typeof(T)](value);
            }
            return value.ToString();
        }
    }
}
