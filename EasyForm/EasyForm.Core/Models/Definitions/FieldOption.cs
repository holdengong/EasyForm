using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.Core.Models.Definitions
{
    public class FieldOption
    {
        public string Label { get; set; }
        public int Value { get; set; }
        public List<FieldOption> Children { get; set; }
    }
}
