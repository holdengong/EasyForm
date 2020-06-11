using EasyForm.Core.Interfaces;

namespace EasyForm.Core.Models.Definitions.Base
{
    public abstract class StringFieldDefinition : FieldDefinition<string>,
        IFuzzyFilterableField, 
        ISortableField,
        IUniqueableField
    {
        public StringFieldDefinition()
        {

        }

        public StringFieldDefinition(string fieldName, string displayName)
     : base(fieldName, displayName)
        {
        }

        public int MaxLength { get; set; } = 255;
        public string Placeholder { get; set; }
        public bool IsUnique { get; set; }
        public bool AllowFilter { get; set; }
        public bool AllowSort { get; set; }
    }
}
