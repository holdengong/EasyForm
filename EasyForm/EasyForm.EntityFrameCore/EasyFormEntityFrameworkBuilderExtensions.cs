using EasyForm.Core.Interfaces;
using EasyForm.EntityFrameCore.Contexts;
using EasyForm.EntityFrameCore.Interfaces;
using EasyForm.EntityFrameCore.Options;
using Microsoft.EntityFrameworkCore;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EasyFormEntityFrameworkBuilderExtensions
    {
        public static IEasyFormBuilder AddFormStore(this IEasyFormBuilder builder,
            Action<FormStoreOptions> storeOptionsAction = null)
        {
            builder.Services.AddFormStore(storeOptionsAction);
            return builder;
        }

        public static IServiceCollection AddFormStore(this IServiceCollection services,
          Action<FormStoreOptions> storeOptionsAction = null)
        {
            return services.AddFormStore<FormDbContext>(storeOptionsAction);
        }

        public static IServiceCollection AddFormStore<TContext>(
            this IServiceCollection services,
            Action<FormStoreOptions> storeOptionsAction = null)
            where TContext : DbContext, IFormDbContext
        {
            var options = new FormStoreOptions();
            services.AddSingleton(options);
            storeOptionsAction?.Invoke(options);

            services.AddDbContext<TContext>(dbCtxBuilder =>
            {
                options.ConfigureDbContext?.Invoke(dbCtxBuilder);
            });

            services.AddScoped<IFormDbContext, TContext>();

            return services;
        }
    }
}
