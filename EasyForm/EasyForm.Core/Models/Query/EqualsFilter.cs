using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Definitions.Base;

namespace EasyForm.Core.Models.Query
{
    public class EqualsFilter<TFieldDefinition, TDataType> : IRecordFilter
        where TFieldDefinition : FieldDefinition<TDataType>, IFilterableField
    {
        public EqualsFilter(TFieldDefinition fieldDefinition,TDataType value)
        {
            FieldDefinition = fieldDefinition;
            Value = value;
        }

        public TFieldDefinition FieldDefinition { get; set; }

        public TDataType Value { get; set; }
    }
}
