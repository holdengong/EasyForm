using System;

namespace EasyForm.Core.Models.Forms.Base
{
    public abstract class ObjectField : Field<object>
    {
        public ObjectField()
        {
        }

        public ObjectField(string fieldName, string displayName)
        : base(fieldName, displayName)
        {
        }
    }

    public abstract class ObjectField<TObjectType> : ObjectField
    {
        public ObjectField()
        {
        }

        public ObjectField(string fieldName, string displayName)
        : base(fieldName, displayName)
        {
        }
    }
}
