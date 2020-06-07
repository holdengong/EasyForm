using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Definitions.Base;
using System.Collections.Generic;

namespace EasyForm.Core.Models.Definitions
{
    public class CascaderFieldDefinition : ObjectFieldDefinition<OptionWithChild<int>>, IFieldHasOptions<int, OptionWithChild<int>>
    {
        public IEnumerable<OptionWithChild<int>> Options { get; set; }
    }
}
