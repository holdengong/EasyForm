using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Definitions.Base;
using EasyForm.Core.Models.Query;

namespace EasyForm.Core.Extensions
{
    public static class QueryBuilders
    {
        public static ContainsFilter<TFieldDefinition, TDataType> Contains<TFieldDefinition, TDataType>
            (TFieldDefinition fieldDefinition, TDataType value)
             where TFieldDefinition : FieldDefinition<TDataType>, IFuzzyFilterableField
        {
            return new ContainsFilter<TFieldDefinition, TDataType>(fieldDefinition, value);
        }

        public static RecordSorter<TFieldDefinition> SortBy<TFieldDefinition>
            (TFieldDefinition fieldDefinition,SortDirection sortDirection)
             where TFieldDefinition : FieldDefinition, ISortableField
        {
            return new RecordSorter<TFieldDefinition>(fieldDefinition, sortDirection);
        }
    }
}
