using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Definitions.Base;

namespace EasyForm.Core.Models.Query
{
    public class RangeFilter<TFieldDefinition, TDataType> : IRecordFilter
        where TFieldDefinition : FieldDefinition<TDataType>, IRangeFilterableField
    {
        public RangeFilter(TFieldDefinition fieldDefinition,TDataType min,TDataType max)
        {
            FieldDefinition = fieldDefinition;
            Min = min;
            Max = max;
        }

        public TFieldDefinition FieldDefinition { get; set; }
        public TDataType Min { get; set; }
        public TDataType Max { get; set; }
    }
}
