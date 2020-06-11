using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Definitions.Base;

namespace EasyForm.Core.Models.Query
{
    public class RecordSorter<TFieldDefinition> : IRecordSorter
       where TFieldDefinition : FieldDefinition, ISortableField
    {
        public RecordSorter(TFieldDefinition fieldDefinition, SortDirection sortDirection)
        {
            FieldDefinition = fieldDefinition;
            SortDirection = sortDirection;
        }

        public TFieldDefinition FieldDefinition { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}
