using EasyForm.Core.Configuration;
using EasyForm.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace EasyForm.Core
{
    public static class EasyFormServiceCollectionExtensions
    {
        public static IEasyFormBuilder AddEasyForm(this IServiceCollection services, Action<EasyFormOptions> setupAction)
        {
            services = services.Configure(setupAction);
            return new EasyFormBuilder(services);
        }

        public static IEasyFormBuilder AddInMemoryForms(this IEasyFormBuilder builder,IEnumerable<Form> forms)
        {
            builder.Services.AddSingleton(forms);

            return builder;
        }
    }
}
