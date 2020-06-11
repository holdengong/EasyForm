using EasyForm.Core.Interfaces;
using System;

namespace EasyForm.Core.Models.Definitions.Base
{
    public abstract class DateTimeFieldDefinition : FieldDefinition, 
        ISortableField, 
        IFilterableField, 
        IUniqueableField
    {
        public string Placeholder { get; set; }
        public DateTime? DefaultValue { get; set; }
        public bool AllowSort { get; set; }
        public bool AllowFilter { get; set; }
        public bool IsUnique { get; set; }
    }
}
