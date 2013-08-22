using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace linq2ga.Core
{
    /// <summary>
    /// The generic implementation of BaseField
    /// </summary>
    /// <typeparam name="T">The value data type</typeparam>
    public abstract class BaseField<T> : BaseField
    {
        #region operators
        /// <summary>
        /// Implicitly converts the value to BaseField
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static implicit operator T(BaseField<T> m)
        {
            return m.Value;
        }
        #endregion

        #region public

        ///// <summary>
        ///// 
        ///// </summary>
        //public virtual string FieldName
        //{
        //    get
        //    {
        //        return null;
        //    }
        //}

        /// <summary>
        /// Value object
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Sets value from given object
        /// </summary>
        /// <param name="value">String value</param>
        internal override void SetValue(string value)
        {
            try
            {
                Value = FieldConverter.GetValue(value);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Returns the value boxed to object
        /// </summary>
        /// <returns>Object value</returns>
        internal override object GetValue()
        {
            return Value;
        }

        /// <summary>
        /// Returns the Data field converter
        /// </summary>
        internal virtual IFieldConverter<T> FieldConverter
        {
            get
            {
                return new DefaultFieldConverter<T>();
            }
        }

        /// <summary>
        /// Returns the string view of the value
        /// </summary>
        /// <returns>String value</returns>
        internal override string GetStringValue()
        {
            return FieldConverter.GetStringValue(Value);
        }

        /// <summary>
        /// Sets value from given object
        /// </summary>
        /// <param name="value">Object value</param>
        internal override void SetValue(object value)
        {
            Value = (T)value;
        }
        #endregion
    }

}
