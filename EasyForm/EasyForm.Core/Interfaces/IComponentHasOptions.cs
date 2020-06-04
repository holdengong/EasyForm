using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.Core.Interfaces
{
    public interface IComponentHasOptions<TOptionValueType, TOptionType>
        where TOptionType : Option<TOptionValueType>
        where TOptionValueType:struct
    {
        IEnumerable<TOptionType> Options { get; set; }
    }
}
