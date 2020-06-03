using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.Core.Models
{
    public class Record
    {
        public string Id { get; set; }
        public string FormId { get; set; }
        public IDictionary<string, object> Values { get; set; }
    }
}
