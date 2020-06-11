using EasyForm.Core.Interfaces;

namespace EasyForm.Core.Models.Definitions.Base
{
    public class IntFieldDefinition : FieldDefinition, 
        ISortableField, 
        IFilterableField, 
        IUniqueableField
    {
        public int? Max { get; set; }
        public int? Min { get; set; }
        public int? DefaultValue { get; set; }
        public bool IsUnique { get; set; }
        public bool AllowSort { get; set; }
        public bool AllowFilter { get; set; }
    }
}
