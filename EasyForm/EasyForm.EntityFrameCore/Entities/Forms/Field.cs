using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.EntityFrameCore.Entities.Forms
{
    public class Field : BaseEntity
    {
        public string FieldName { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public int FormId { get; set; }
        public Form Form { get; set; }
        public string FieldType { get; set; }
    }
}
