namespace EasyForm.Core.Models.Abstract
{
    public abstract class BoolField : Field
    {
        public bool? DefaultValue { get; set; }
        public bool? Value { get; set; }
    }
}
