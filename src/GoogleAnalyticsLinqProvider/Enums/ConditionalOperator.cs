using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleAnalyticsLinqProvider.Parsers.ExpressionParsers
{
    internal enum ConditionalOperator
    {
        Equals,
        NotEquals,
        Greater,
        Less,
        EqualsOrGereater,
        EqualsOrLess,
        Contains,
        NotContains,
        Match,
        NotMatch,
        StartWith,
        EndWith
    }
}
