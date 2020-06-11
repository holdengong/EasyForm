using EasyForm.Core.Interfaces;

namespace EasyForm.Core.Models.Definitions.Base
{
    public class IntFieldDefinition : FieldDefinition<int?>, 
        ISortableField,
        IRangeFilterableField, 
        IUniqueableField
    {
        public IntFieldDefinition()
        {
        }

        public IntFieldDefinition(string fieldName,string displayName)
            :base(fieldName,displayName)
        {
        }
        public int? Max { get; set; }
        public int? Min { get; set; }
        public bool IsUnique { get; set; }
        public bool AllowSort { get; set; }
        public bool AllowFilter { get; set; }
    }
}
