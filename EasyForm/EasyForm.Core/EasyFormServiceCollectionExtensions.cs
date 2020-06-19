using EasyForm.Core.Configuration;
using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Forms;
using EasyForm.Core.Stores;
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

        public static IEasyFormBuilder AddInMemoryFormDefinitions(this IEasyFormBuilder builder,IEnumerable<Form> forms)
        {
            builder.Services.AddSingleton(forms);

            builder.Services.AddTransient<IFormStore, InMemoryFormStore>();

            return builder;
        }
    }
}
