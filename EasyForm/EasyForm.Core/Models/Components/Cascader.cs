using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.Core.Models.Components
{
    public class Cascader : ArrayField<OptionWithChild<int>>, IComponentHasOptions<int,OptionWithChild<int>>
    {
        public IEnumerable<OptionWithChild<int>> Options { get; set; }
    }
}
