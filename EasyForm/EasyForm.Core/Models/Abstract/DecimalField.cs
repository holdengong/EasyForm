namespace EasyForm.Core.Models.Abstract
{
    public abstract class DecimalField : Field
    {
        public decimal Max { get; set; }
        public decimal Min { get; set; }
        public decimal DefaultValue { get; set; }
        public decimal Value { get; set; }
    }
}
