using EasyForm.Core.Models.Abstract;

namespace EasyForm
{
    public abstract class StringField : Field
    { 
        public string MaxLength { get; set; }
        public string DefaultValue { get; set; }
        public string Placeholder { get; set; }
        public string Value { get; set; }
    }
}
