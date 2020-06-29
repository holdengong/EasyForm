using System;

namespace EasyForm.EntityFrameCore.Entities.Forms
{
    public class DateTimeField : Field
    {
        public bool AllowFilter { get; set; }
        public bool AllowSort { get; set; }
        public DateTime? DefaultValue { get; set; }
        public bool IsUnique { get; set; }
        public string Placeholder { get; set; }
    }
}
