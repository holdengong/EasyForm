using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Abstract;
using System.Collections.Generic;

namespace EasyForm.Core.Models.Components
{
    public class Checkbox : ArrayField<int>, IComponentHasOptions<int,Option<int>>
    {
        public IEnumerable<Option<int>> Options { get; set; }
    }
}
