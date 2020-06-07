namespace EasyForm.Core.Models.Definitions.Base
{
    public abstract class ObjectFieldDefinition<T> : FieldDefinition
    {
        public virtual T DefaultValue { get; set; }
    }
}
