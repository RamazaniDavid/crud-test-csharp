using System;
using System.Collections.Generic;
using System.Text;
using Mc2.CrudTest.Core.Caching;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Caching.StackExchangeRedis;
namespace Mc2.CrudTest.Core.Infrastructure
{
    public class CacheStartup : IApplicationStartup
    {
        public MiddleWarePriority Priority => MiddleWarePriority.Normal;

        public void Configure(IApplicationBuilder app)
        {
           
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {

            services.AddMemoryCache();

            services.AddScoped<ICacheManager, MemoryCacheManager>();

        }


    }
}
