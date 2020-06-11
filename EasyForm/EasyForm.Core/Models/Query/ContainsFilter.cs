using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Definitions.Base;

namespace EasyForm.Core.Models.Query
{
    public class ContainsFilter<TFieldDefinition, TDataType> : IRecordFilter
        where TFieldDefinition : FieldDefinition<TDataType>, IFuzzyFilterableField
    {
        public ContainsFilter(TFieldDefinition fieldDefinition,TDataType value)
        {
            FieldDefinition = fieldDefinition;
            Value = value;
        }

        public TFieldDefinition FieldDefinition { get; set; }

        public TDataType Value { get; set; }
    }
}
