using EasyForm.Core.Models.Abstract;

namespace EasyForm
{
    public abstract class NumberField<T> : Field
        where T : struct
    {
        public T Max { get; set; }
        public T Min { get; set; }
        public T DefaultValue { get; set; }
        public T Value { get; set; }
    }
}
