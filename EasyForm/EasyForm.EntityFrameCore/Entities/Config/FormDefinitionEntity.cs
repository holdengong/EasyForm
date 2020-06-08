using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.EntityFrameCore.Entities.Config
{
    public class FormDefinitionEntity : BaseEntity
    {
        public string FormId { get; set; }
        public string Description { get; set; }
    }
}
