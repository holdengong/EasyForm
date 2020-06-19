using EasyForm.Core.Models.Forms.Base;

namespace EasyForm.Core.Models.Forms
{
    public class ColorPickerField : StringField
    {
        public ColorPickerField()
        {

        }

        public ColorPickerField(string fieldName, string displayName)
 : base(fieldName, displayName)
        {
        }
    }
}
