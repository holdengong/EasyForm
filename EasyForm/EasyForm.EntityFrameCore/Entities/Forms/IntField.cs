namespace EasyForm.EntityFrameCore.Entities.Forms
{
    public class IntField : Field
    {
        public int? Max { get; set; }
        public int? Min { get; set; }
        public int? DefaultValue { get; set; }
        public bool AllowFilter { get; set; }
        public bool AllowSort { get; set; }
        public bool IsUnique { get; set; }
    }
}
