using EasyForm.Core.Models.Forms.Base;
using System;
using System.Collections.Generic;

namespace EasyForm.Core.Models.Forms
{
    public class Form
    {
        public string Key { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string Description { get; set; }
        public IEnumerable<Field> Fields { get; set; }
    }
}
