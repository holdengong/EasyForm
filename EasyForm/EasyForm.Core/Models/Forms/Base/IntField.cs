using EasyForm.Core.Interfaces;

namespace EasyForm.Core.Models.Forms.Base
{
    public class IntField : FieldDefinition<int?>,
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
