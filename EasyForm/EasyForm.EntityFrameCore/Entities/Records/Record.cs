using EasyForm.EntityFrameCore.Entities.Forms;
using System;
using System.Collections.Generic;

namespace EasyForm.EntityFrameCore.Entities.Records
{
    public class Record : BaseEntity
    {
        public string FormKey { get; set; }
        public string Key { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Updated { get; set; }
        public IEnumerable<BoolFieldValue> BoolFieldValues { get; set; }
        public IEnumerable<DateTimeFieldValue> DateTimeFieldValues { get; set; }
        public IEnumerable<DecimalFieldValue> DecimalFieldValues { get; set; }
        public IEnumerable<IntFieldValue> IntFieldValues { get; set; }
        public IEnumerable<ObjectFieldValue> ObjectFieldValues { get; set; }
    }
}
