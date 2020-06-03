using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.Core.Interfaces
{
    public interface IComponentHasOptions<T>
        where T : struct
    {
        IEnumerable<Option<T>> Options { get; set; }
    }
}
