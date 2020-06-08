using EasyForm.Core.Extensions;
using EasyForm.Core.Models.Records.Base;
using System.Collections.Generic;

namespace EasyForm.Core.Models.Records
{
    public class FormRecord
    {
        public string FormDefinitionId { get; set; }
        public IEnumerable<FieldValue> FieldValues { get; set; }
        public bool HasValue()
        {
            return FieldValues.IsNullOrEmpty();
        }
    }
}