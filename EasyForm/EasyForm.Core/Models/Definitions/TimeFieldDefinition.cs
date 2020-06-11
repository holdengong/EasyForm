using EasyForm.Core.Models.Definitions.Base;

namespace EasyForm.Core.Models.Definitions
{
    public class TimeFieldDefinition : StringFieldDefinition
    {
        public TimeFieldDefinition()
        {

        }

        public TimeFieldDefinition(string fieldName,string displayName)
            :base(fieldName,displayName)
        {

        }
    }
}
