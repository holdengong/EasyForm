namespace EasyForm.Core.Models.Abstract
{
    public abstract class ArrayField<T> : Field
    {
        public virtual T[] DefaultValue { get; set; }
        public virtual T[] Value { get; set; }
    }
}
