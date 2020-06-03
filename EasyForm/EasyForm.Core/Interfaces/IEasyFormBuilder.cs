using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.Core.Interfaces
{
    public interface IEasyFormBuilder
    {
        IServiceCollection Services { get; }
    }
}
