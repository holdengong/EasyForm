using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Forms.Base;

namespace EasyForm.Core.Models.Forms
{
    public class IntField : Field<int?>,
        ISortableField,
        IRangeFilterableField,
        IUniqueableField
    {
        public IntField()
        {
        }

        public IntField(string fieldName, string displayName)
            : base(fieldName, displayName)
        {
        }
        public int? Max { get; set; }
        public int? Min { get; set; }
        public bool IsUnique { get; set; }
        public bool AllowSort { get; set; }
        public bool AllowFilter { get; set; }
    }
}
