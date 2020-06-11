using EasyForm.Core.Models.Definitions.Base;

namespace EasyForm.Core.Models.Definitions
{
    public class RichTextFieldDefinition : TextFieldDefinition
    {
        public RichTextFieldDefinition()
        {

        }

        public RichTextFieldDefinition(string fieldName,string displayName)
            :base(fieldName,displayName)
        {

        }
    }
}
