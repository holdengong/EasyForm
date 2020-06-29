using EasyForm.Core.Interfaces;

namespace EasyForm.Core.Models.Forms.Base
{
    public abstract class Field
    {
        public Field()
        {
        }

        public Field(string fieldName, string displayName)
        {
            FieldName = fieldName;
            DisplayName = displayName;
        }

        public string FieldName { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
    }

    public abstract class Field<TDataType> : Field
    {
        public Field()
        {
        }

        public Field(string fieldName, string displayName)
            : base(fieldName, displayName)
        {
        }

        public TDataType DefaultValue { get; set; }
    }
}
