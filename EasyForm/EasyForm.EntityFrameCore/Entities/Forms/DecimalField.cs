using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.EntityFrameCore.Entities.Forms
{
    public class DecimalField : Field
    {
        public decimal? Max { get; set; }
        public decimal? Min { get; set; }
        public decimal? DefaultValue { get; set; }
    }
}
