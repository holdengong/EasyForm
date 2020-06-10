using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.EntityFrameCore.Entities.Config
{
    public class FormRecordEntity : BaseEntity
    {
        public int FormId { get; set; }
        public FormEntity Form { get; set; }
        public List<BoolFieldValueEntity> BoolFieldValues { get; set; }
        public List<DateTimeFieldValueEntity> DateTimeFieldValues { get; set; }
        public List<DecimalFieldValueEntity> DecimalFieldValues { get; set; }
        public List<IntFieldValueEntity> IntFieldValues { get; set; }
        public List<ObjectFieldValueEntity> ObjectFieldValues { get; set; }
    }
}
