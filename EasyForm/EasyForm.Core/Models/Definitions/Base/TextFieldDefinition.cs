using EasyForm.Core.Interfaces;

namespace EasyForm.Core.Models.Definitions.Base
{
    public abstract class TextFieldDefinition : FieldDefinition, 
        IFilterableField
    {
        public string DefaultValue { get; set; }
        public string Placeholder { get; set; }
        public bool AllowFilter { get; set; }
    }
}
