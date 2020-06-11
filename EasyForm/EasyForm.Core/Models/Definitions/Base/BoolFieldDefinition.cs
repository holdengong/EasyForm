using EasyForm.Core.Interfaces;

namespace EasyForm.Core.Models.Definitions.Base
{
    public abstract class BoolFieldDefinition : FieldDefinition<bool?>
    {
        public BoolFieldDefinition()
        {
        }

        public BoolFieldDefinition(string fieldName,string displayName)
            :base(fieldName,displayName)
        {
        }
    }
}
