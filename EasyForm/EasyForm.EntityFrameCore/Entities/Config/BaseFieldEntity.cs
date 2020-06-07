using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.EntityFrameCore.Entities.Config
{
    public class BaseFieldEntity : BaseEntity
    {
        public string FieldName { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public bool IsUnique { get; set; }
    }
}
