using EasyForm.Core.Models.Abstract;
using System.Collections.Generic;

namespace EasyForm
{
    public class Form
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public IEnumerable<Field> Fields { get; set; }
    }
}
