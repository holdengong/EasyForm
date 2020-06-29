using EasyForm.Core.Filters;
using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Forms.Base;

namespace EasyForm.Core.Extensions
{
    public static class QueryBuilders
    {
        public static ContainsFilter<TFieldDefinition, TDataType> Contains<TFieldDefinition, TDataType>
            (TFieldDefinition fieldDefinition, TDataType value)
             where TFieldDefinition : Field<TDataType>, IFuzzyFilterableField
        {
            return new ContainsFilter<TFieldDefinition, TDataType>(fieldDefinition, value);
        }

        public static RecordSorter<TFieldDefinition> SortBy<TFieldDefinition>
            (TFieldDefinition fieldDefinition,SortDirection sortDirection)
             where TFieldDefinition : Field, ISortableField
        {
            return new RecordSorter<TFieldDefinition>(fieldDefinition, sortDirection);
        }
    }
}
