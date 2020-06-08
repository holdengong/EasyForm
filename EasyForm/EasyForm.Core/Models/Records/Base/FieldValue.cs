using EasyForm.Core.Models.Definitions.Base;
using System;

namespace EasyForm.Core.Models.Records.Base
{
    public abstract class FieldValue
    {
        public FieldDefinition FieldDefinition { get; set; }

        public override bool Equals(object obj)
        {
            var that = (FieldValue)obj;
            return this.FieldDefinition.FieldName.Equals(that.FieldDefinition.FieldName, StringComparison.CurrentCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return this.FieldDefinition.FieldName.GetHashCode();
        }
    }

    public abstract class FieldRecord<T> : FieldValue
    {
        public T Value { get; set; }
    }
}
