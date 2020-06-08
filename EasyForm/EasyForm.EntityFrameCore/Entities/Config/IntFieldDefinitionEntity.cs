using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.EntityFrameCore.Entities.Config
{
    public class IntFieldDefinitionEntity : BaseFieldDefinitionEntity
    {
        public int? Max { get; set; }
        public int? Min { get; set; }
        public int? DefaultValue { get; set; }
    }
}
