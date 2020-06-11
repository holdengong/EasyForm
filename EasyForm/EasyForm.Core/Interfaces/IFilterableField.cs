using EasyForm.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.Core.Interfaces
{
    public interface IFilterableField
    {
        bool AllowFilter { get; set; }
    }
}
