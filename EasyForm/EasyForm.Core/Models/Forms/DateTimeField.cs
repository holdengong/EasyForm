using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Forms.Base;
using System;

namespace EasyForm.Core.Models.Forms
{
    public class DateTimeField : Field<DateTime?>,
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
}
