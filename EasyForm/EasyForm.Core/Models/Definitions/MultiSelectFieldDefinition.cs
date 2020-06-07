using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Definitions.Base;
using System.Collections.Generic;

namespace EasyForm.Core.Models.Definitions
{
    public class MultiSelectFieldDefinition : ObjectFieldDefinition<int>, IFieldHasOptions<int, Option<int>>
    {
        public IEnumerable<Option<int>> Options { get; set; }
    }
}
