using EasyForm.Core.Interfaces;
using System;

namespace EasyForm.Core.Models.Definitions.Base
{
    public abstract class DateTimeFieldDefinition : FieldDefinition
    {
        public string Placeholder { get; set; }
        public DateTime? DefaultValue { get; set; }
    }
}
