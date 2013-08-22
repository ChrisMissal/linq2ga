using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace linq2ga.Exceptions
{
    public class NotSupportedExpressionException : Exception
    {
        public NotSupportedExpressionException(LambdaExpression expression, string message)
            : base(message + Environment.NewLine + expression.ToString())
        {
                Expression = expression;
        }
        public NotSupportedExpressionException(LambdaExpression expression, string message, Exception innerException)
            : base(message + Environment.NewLine + expression.ToString(), innerException)
        {
                Expression = expression;
        }

        public LambdaExpression Expression { get; private set; }
    }
}
