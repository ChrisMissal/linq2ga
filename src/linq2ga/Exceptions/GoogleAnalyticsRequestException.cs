using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace linq2ga.Exceptions
{
    public class GoogleAnalyticsRequestException : Exception
    {
        public GoogleAnalyticsRequestException(string message)
            : base(message) { }
        public GoogleAnalyticsRequestException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
