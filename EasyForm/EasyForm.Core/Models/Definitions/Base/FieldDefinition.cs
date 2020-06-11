using EasyForm.Core.Interfaces;

namespace EasyForm.Core.Models.Definitions.Base
{
    public abstract class FieldDefinition
    {
        public FieldDefinition()
        {
        }

        public FieldDefinition(string fieldName, string displayName)
        {
            FieldName = fieldName;
            DisplayName = displayName;
        }

        public string FieldName { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
    }

    public abstract class FieldDefinition<TDataType> : FieldDefinition
    {
        public FieldDefinition()
        {
        }

        public FieldDefinition(string fieldName, string displayName)
            :base(fieldName,displayName)
        {
        }

        public TDataType DefaultValue { get; set; }
    }
}
