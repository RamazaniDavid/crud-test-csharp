using Mc2.CrudTest.Core.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Data.Infrastructure
{
    public class DataBaseStartup : IApplicationStartup
    {
        public MiddleWarePriority Priority => MiddleWarePriority.AboveNormal;

        public void Configure(IApplicationBuilder app)
        {
            
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddDbContextPool<IApplcationDbContext, SqlServerApplicationContext>(
              c => c.UseSqlServer(configuration.GetConnectionString("CustomerDB")).UseLazyLoadingProxies()
          , poolSize: 16);
        }
    }
}
