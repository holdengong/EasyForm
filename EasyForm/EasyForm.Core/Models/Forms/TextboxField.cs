using EasyForm.Core.Models.Forms.Base;

namespace EasyForm.Core.Models.Forms
{
    public class TextboxField : StringField
    {
        public TextboxField()
        {

        }

        public TextboxField(string fieldName, string displayName)
      : base(fieldName, displayName)
        {
        }
    }
}
