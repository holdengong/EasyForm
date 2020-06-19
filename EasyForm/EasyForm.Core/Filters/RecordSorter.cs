using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Forms.Base;

namespace EasyForm.Core.Filters
{
    public class RecordSorter<TFieldDefinition> : IRecordSorter
       where TFieldDefinition : Field, ISortableField
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
