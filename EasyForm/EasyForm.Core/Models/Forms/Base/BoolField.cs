namespace EasyForm.Core.Models.Forms.Base
{
    public abstract class BoolField : FieldDefinition<bool?>
    {
        public BoolField()
        {
        }

        public BoolField(string fieldName, string displayName)
            : base(fieldName, displayName)
        {
        }
    }
}
