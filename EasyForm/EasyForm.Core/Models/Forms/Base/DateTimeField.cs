using EasyForm.Core.Interfaces;
using System;

namespace EasyForm.Core.Models.Forms.Base
{
    public abstract class DateTimeField : FieldDefinition<DateTime?>,
        ISortableField,
        IRangeFilterableField,
        IUniqueableField
    {
        public DateTimeField()
        {

        }

        public DateTimeField(string fieldName, string displayName)
          : base(fieldName, displayName)
        {
        }

        public string Placeholder { get; set; }
        public bool AllowSort { get; set; }
        public bool AllowFilter { get; set; }
        public bool IsUnique { get; set; }
    }
}
