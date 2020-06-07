using EasyForm.Core.Interfaces;

namespace EasyForm.Core.Models.Definitions.Base
{
    public abstract class BoolFieldDefinition : FieldDefinition
    {
        public bool? DefaultValue { get; set; }
    }
}
