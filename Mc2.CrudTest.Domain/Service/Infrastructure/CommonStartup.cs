using Mc2.CrudTest.Core.Infrastructure;
using Mc2.CrudTest.Service.Catalog;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Service.Infrastructure
{
    public class CommonStartup:IApplicationStartup
    {
        public MiddleWarePriority Priority => MiddleWarePriority.Normal;

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<MapsterConfigMiddleWare>();
        }
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICustomerService, CustomerService>();
        }


    }
}
