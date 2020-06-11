namespace EasyForm.Core.Models.Definitions.Base
{
    public abstract class ObjectFieldDefinition<TObjectType> : FieldDefinition<TObjectType>
    {
        public ObjectFieldDefinition()
        {
        }

        public ObjectFieldDefinition(string fieldName, string displayName)
        : base(fieldName, displayName)
        {
        }
    }
}
