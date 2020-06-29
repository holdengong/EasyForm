using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Forms.Base;

namespace EasyForm.Core.Filters
{
    public class ContainsFilter<TFieldDefinition, TDataType> : IRecordFilter
        where TFieldDefinition : Field<TDataType>, IFuzzyFilterableField
    {
        public ContainsFilter(TFieldDefinition fieldDefinition, TDataType value)
        {
            FieldDefinition = fieldDefinition;
            Value = value;
        }

        public TFieldDefinition FieldDefinition { get; set; }

        public TDataType Value { get; set; }
    }
}
