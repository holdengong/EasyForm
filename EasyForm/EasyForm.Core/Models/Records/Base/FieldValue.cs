using EasyForm.Core.Models.Forms.Base;
using System;

namespace EasyForm.Core.Models.Records.Base
{
    public abstract class FieldValue
    {
        public Field FieldDefinition { get; set; }

        public override bool Equals(object obj)
        {
            var that = (FieldValue)obj;
            return FieldDefinition.FieldName.Equals(that.FieldDefinition.FieldName, StringComparison.CurrentCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return FieldDefinition.FieldName.GetHashCode();
        }
    }

    public abstract class FieldValue<T> : FieldValue
    {
        public virtual T Value { get; set; }
    }
}
