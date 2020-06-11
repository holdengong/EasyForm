using EasyForm.Core.Models.Definitions.Base;

namespace EasyForm.Core.Models.Definitions
{
    public class TextAreaFieldDefinition : TextFieldDefinition
    {
        public TextAreaFieldDefinition()
        {

        }

        public TextAreaFieldDefinition(string fieldName,string displayName)
        :base(fieldName,displayName)
        {

        }
    }
}
