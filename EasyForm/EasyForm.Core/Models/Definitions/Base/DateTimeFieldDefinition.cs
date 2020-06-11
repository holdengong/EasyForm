using EasyForm.Core.Interfaces;
using System;

namespace EasyForm.Core.Models.Definitions.Base
{
    public abstract class DateTimeFieldDefinition : FieldDefinition<DateTime?>, 
        ISortableField,
        IRangeFilterableField, 
        IUniqueableField
    {
        public DateTimeFieldDefinition()
        {

        }

        public DateTimeFieldDefinition(string fieldName, string displayName)
          : base(fieldName, displayName)
        {
        }

        public string Placeholder { get; set; }
        public bool AllowSort { get; set; }
        public bool AllowFilter { get; set; }
        public bool IsUnique { get; set; }
    }
}
