using EasyForm.Core.Models.Definitions.Base;
using System.Collections.Generic;

namespace EasyForm.Core.Models.Definitions
{
    public class FormDefinition
    {
        public string FormId { get; set; }
        public string Description { get; set; }
        public IEnumerable<FieldDefinition> Fields { get; set; }
    }
}
