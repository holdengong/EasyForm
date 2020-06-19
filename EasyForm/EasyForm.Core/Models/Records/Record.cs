using EasyForm.Core.Extensions;
using EasyForm.Core.Models.Records.Base;
using System;
using System.Collections.Generic;

namespace EasyForm.Core.Models.Records
{
    public class Record
    {
        public string Key { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string FormKey { get; set; }
        public IEnumerable<FieldValue> Values { get; set; }
        public bool HasValue()
        {
            return Values.IsNullOrEmpty();
        }
    }
}