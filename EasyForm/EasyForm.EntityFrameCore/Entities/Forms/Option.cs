using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.EntityFrameCore.Entities.Forms
{
    public class Option : BaseEntity
    {
        public string Purpose { get; set; }
        public string Label { get; set; }
        public int Value { get; set; }
        public int ParentId { get; set; }
    }
}
