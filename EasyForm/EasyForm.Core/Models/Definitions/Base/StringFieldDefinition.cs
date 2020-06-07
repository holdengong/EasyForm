using EasyForm.Core.Interfaces;

namespace EasyForm.Core.Models.Definitions.Base
{
    public abstract class StringFieldDefinition : FieldDefinition
    {
        public int MaxLength { get; set; } = 255;
        public string DefaultValue { get; set; }
        public string Placeholder { get; set; }
        public bool IsUnique { get; set; }
    }
}
