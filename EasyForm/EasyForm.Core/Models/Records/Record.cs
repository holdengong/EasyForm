using EasyForm.Core.Extensions;
using EasyForm.Core.Models.Records.Base;
using System.Collections.Generic;

namespace EasyForm.Core.Models.Records
{
    public class Record
    {
        public string Key { get; set; }
        public string FormKey { get; set; }
        public IEnumerable<FieldValue> FieldValues { get; set; }
        public bool HasValue()
        {
            return FieldValues.IsNullOrEmpty();
        }
    }
}