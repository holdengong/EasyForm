using EasyForm.Core.Interfaces;

namespace EasyForm.Core.Models.Forms.Base
{
    public class DecimalField : FieldDefinition<decimal?>,
        ISortableField,
        IRangeFilterableField,
        IUniqueableField
    {
        public DecimalField()
        {

        }

        public DecimalField(string fieldName, string displayName)
          : base(fieldName, displayName)
        {
        }

        public decimal? Max { get; set; }
        public decimal? Min { get; set; }
        public bool AllowSort { get; set; }
        public bool AllowFilter { get; set; }
        public bool IsUnique { get; set; }
    }
}
