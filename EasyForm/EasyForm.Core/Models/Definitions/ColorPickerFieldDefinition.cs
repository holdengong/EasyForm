using EasyForm.Core.Models.Definitions.Base;

namespace EasyForm.Core.Models.Definitions
{
    public class ColorPickerFieldDefinition : StringFieldDefinition
    {
        public ColorPickerFieldDefinition()
        {

        }

        public ColorPickerFieldDefinition(string fieldName, string displayName)
 : base(fieldName, displayName)
        {
        }
    }
}
