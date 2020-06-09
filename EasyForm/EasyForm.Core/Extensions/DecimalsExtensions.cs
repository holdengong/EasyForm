using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EasyForm.Core.Extensions
{
    internal static class DecimalsExtensions
    {
        [DebuggerStepThrough]
        public static bool IsOutOfRange(this decimal? num, decimal? min, decimal? max)
        {
            if (!num.HasValue && !min.HasValue && !max.HasValue) return false;
            if (!num.HasValue) return true;
            return num.Value.IsOutOfRange(min, max);
        }

        [DebuggerStepThrough]
        public static bool IsOutOfRange(this decimal num, decimal? min, decimal? max)
        {
            if (min.HasValue && num < min.Value) return true;
            if (max.HasValue && num > max.Value) return true;
            return false;
        }
    }
}