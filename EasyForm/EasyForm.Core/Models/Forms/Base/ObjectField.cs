using System;

namespace EasyForm.Core.Models.Forms.Base
{
    public abstract class ObjectField : FieldDefinition<object>
    {
        public Type ObjType { get; set; }

        public ObjectField()
        {
        }

        public ObjectField(string fieldName, string displayName, Type objType)
        : base(fieldName, displayName)
        {
            ObjType = objType;
        }
    }

    public abstract class ObjectField<TObjectType> : ObjectField
    {
        public ObjectField()
        {
        }

        public ObjectField(string fieldName, string displayName)
        : base(fieldName, displayName, typeof(TObjectType))
        {
        }
    }
}
