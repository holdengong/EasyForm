using System.Collections.Generic;

namespace EasyForm.Core.Models.Forms
{
    public class Option
    {
        public string Label { get; set; }
        public string Value { get; set; }
        public List<Option> Children { get; set; }
    }
}
