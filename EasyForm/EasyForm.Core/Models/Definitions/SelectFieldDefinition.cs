using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Definitions.Base;
using System.Collections.Generic;

namespace EasyForm.Core.Models.Definitions
{
    public class SelectFieldDefinition : IntFieldDefinition, IFieldHasOptions
    {
        public IEnumerable<FieldOption> Options { get; set; }
        public string FieldOptionsName { get; set; }
        public IFieldOptionsStore FieldOptionsStore { get; set; }
    }
}
