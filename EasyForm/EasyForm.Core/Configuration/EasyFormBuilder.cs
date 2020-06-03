using EasyForm.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EasyForm.Core.Configuration
{
    public class EasyFormBuilder : IEasyFormBuilder
    {
        public EasyFormBuilder(IServiceCollection services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public IServiceCollection Services { get; }
    }
}
