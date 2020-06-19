using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.EntityFrameCore.Entities.Records
{
    public class BaseFieldValue : BaseEntity
    {
        public int RecordId { get; set; }
        public Record Record { get; set; }
        public string FieldName { get; set; }
    }
}
