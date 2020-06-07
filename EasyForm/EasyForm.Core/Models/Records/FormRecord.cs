using EasyForm.Core.Extensions;
using EasyForm.Core.Models.Records.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyForm.Core.Models.Records
{
    public class FormRecord
    {
        public string FormDefinitionId { get; set; }
        public IEnumerable<FieldRecord> FieldRecords { get; set; }
        public bool HasValue()
        {
            return FieldRecords.IsNullOrEmpty();
        }
    }
}