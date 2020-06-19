using EasyForm.EntityFrameCore.Entities.Forms;
using System;
using System.Collections.Generic;

namespace EasyForm.EntityFrameCore.Entities.Records
{
    public class Record : BaseEntity
    {
        public int FormId { get; set; }
        public Form Form { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Updated { get; set; }
        public List<BoolFieldValue> BoolFieldValues { get; set; }
        public List<DateTimeFieldValue> DateTimeFieldValues { get; set; }
        public List<DecimalFieldValue> DecimalFieldValues { get; set; }
        public List<IntFieldValueEntity> IntFieldValues { get; set; }
        public List<ObjectFieldValueEntity> ObjectFieldValues { get; set; }
    }
}
