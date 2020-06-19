using System;

namespace EasyForm.Core.Models.Records.Base
{
    public abstract class ObjectFieldValue<T> : ObjectFieldValue
    {
        public ObjectFieldValue()
            :base(typeof(T))
        {
        }

        public new T Value { get; set; }
    }

    public abstract class ObjectFieldValue : FieldValue<object>
    {
        public Type ObjType { get; set; }
        public ObjectFieldValue(Type objType)
        {
            ObjType = objType;
        }
    }
}
