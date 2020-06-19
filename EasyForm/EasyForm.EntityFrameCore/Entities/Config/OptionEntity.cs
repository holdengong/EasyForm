using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.EntityFrameCore.Entities.Config
{
    public class OptionEntity : BaseEntity
    {
        public string Purpose { get; set; }
        public string Label { get; set; }
        public int Value { get; set; }
        public int ParentId { get; set; }
    }
}
