using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.EntityFrameCore.Entities.Config
{
    public class BaseFieldValueEntity<T> : BaseEntity
    {
        public int RecordId { get; set; }
        public FormRecordEntity Record { get; set; }
        public string FieldName { get; set; }
        public T Value { get; set; }
    }
}
