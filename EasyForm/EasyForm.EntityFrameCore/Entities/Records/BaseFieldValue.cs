using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.EntityFrameCore.Entities.Records
{
    public class BaseFieldValue<T> : BaseEntity
    {
        public int RecordId { get; set; }
        public Record Record { get; set; }
        public string FieldName { get; set; }
        public T Value { get; set; }
    }
}
