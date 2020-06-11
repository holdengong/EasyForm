using EasyForm.Core.Interfaces;

namespace EasyForm.Core.Models.Definitions.Base
{
    public abstract class TextFieldDefinition : FieldDefinition<string>,
        IFuzzyFilterableField
    {
        public TextFieldDefinition()
        {
                
        }

        public TextFieldDefinition(string fieldName, string displayName)
     : base(fieldName, displayName)
        {
        }

        public string Placeholder { get; set; }
        public bool AllowFilter { get; set; }
    }
}
