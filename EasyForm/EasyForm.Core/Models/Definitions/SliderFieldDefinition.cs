using EasyForm.Core.Models.Definitions.Base;

namespace EasyForm.Core.Models.Definitions
{
    public class SliderFieldDefinition : IntFieldDefinition
    {
        public SliderFieldDefinition()
        {

        }

        public SliderFieldDefinition(string fieldName,string displayName)
            :base(fieldName,displayName)
        {

        }
    }
}
