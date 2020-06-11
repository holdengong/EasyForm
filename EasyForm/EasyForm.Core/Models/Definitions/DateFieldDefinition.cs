using EasyForm.Core.Models.Definitions.Base;

namespace EasyForm.Core.Models.Definitions
{
    public class DateFieldDefinition : DateTimeFieldDefinition
    {
        public DateFieldDefinition()
        {
        }

        public DateFieldDefinition(string fieldName, string displayName)
      : base(fieldName, displayName)
        {
        }
    }
}
