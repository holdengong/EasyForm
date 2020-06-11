using EasyForm.Core.Models.Definitions.Base;

namespace EasyForm.Core.Models.Definitions
{
    public class TextboxFieldDefinition : StringFieldDefinition
    {
        public TextboxFieldDefinition()
        {

        }

        public TextboxFieldDefinition(string fieldName, string displayName)
      : base(fieldName, displayName)
        {
        }
    }
}
