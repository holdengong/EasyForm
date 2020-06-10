using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.EntityFrameCore.Entities.Config
{
    public class FormEntity : BaseEntity
    {
        public string FormId { get; set; }
        public string Description { get; set; }
        public List<BoolFieldEntity> BoolFields { get; set; }
        public List<DateTimeFieldEntity> DateTimeFields { get; set; }
        public List<DecimalFieldEntity> DecimalFields { get; set; }
        public List<IntFieldEntity> IntFields { get; set; }
        public List<ObjectFieldEntity> ObjectFields { get; set; }

        public List<FormRecordEntity> Records { get; set; }
    }
}
