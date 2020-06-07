namespace EasyForm.Core.Models.Definitions.Base
{
    public abstract class TextFieldDefinition : FieldDefinition
    {
        public string DefaultValue { get; set; }
        public string Placeholder { get; set; }
    }
}
