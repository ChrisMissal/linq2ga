using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace linq2ga.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IFieldConverter<T>
    {
        T GetValue(string value);
        string GetStringValue(T value);
    }
}
