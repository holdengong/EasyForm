using EasyForm.Core.Interfaces;

namespace EasyForm.Core.Models.Definitions.Base
{
    public abstract class DecimalFieldDefinition : FieldDefinition
    {
        public decimal? Max { get; set; }
        public decimal? Min { get; set; }
        public decimal? DefaultValue { get; set; }
    }
}
