namespace EasyForm.Core.Models.Abstract
{
    public abstract class Field
    {
        public string FieldName { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public bool IsUnique { get; set; }
    }
}
