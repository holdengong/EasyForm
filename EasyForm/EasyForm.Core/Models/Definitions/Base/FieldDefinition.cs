using EasyForm.Core.Interfaces;

namespace EasyForm.Core.Models.Definitions.Base
{
    public abstract class FieldDefinition
    {
        public string FieldName { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
    }
}
