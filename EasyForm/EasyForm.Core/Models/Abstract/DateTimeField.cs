using System;

namespace EasyForm.Core.Models.Abstract
{
    public abstract class DateTimeField : Field
    {
        public string Placeholder { get; set; }
        public DateTime? DefaultValue { get; set; }
        public DateTime? Value { get; set; }
    }
}
