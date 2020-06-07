using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EasyForm.Core.Extensions
{
    internal static class IntsExtensions
    {
        [DebuggerStepThrough]
        public static bool IsOutOfRange(this int? num, int? min, int? max)
        {
            if (!num.HasValue && !min.HasValue && !max.HasValue) return false;
            if (!num.HasValue) return true;
            return num.Value.IsOutOfRange(min, max);
        }

        [DebuggerStepThrough]
        public static bool IsOutOfRange(this int num, int? min, int? max)
        {
            if (min.HasValue && num <= min.Value) return true;
            if (max.HasValue && num >= max.Value) return true;
            return false;
        }
    }
}