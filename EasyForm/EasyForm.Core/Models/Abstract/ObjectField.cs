using EasyForm.Core.Models.Abstract;

namespace EasyForm
{
    public abstract class ObjectField<T> : Field
    {
        public T DefaultValue { get; set; }
        public T Value { get; set; }
    }
}
