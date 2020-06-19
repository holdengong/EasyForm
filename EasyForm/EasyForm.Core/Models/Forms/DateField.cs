using EasyForm.Core.Models.Forms.Base;

namespace EasyForm.Core.Models.Forms
{
    public class DateField : DateTimeField
    {
        public DateField()
        {
        }

        public DateField(string fieldName, string displayName)
      : base(fieldName, displayName)
        {
        }
    }
}
