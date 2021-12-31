using Mc2.CrudTest.Core.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mc2.CrudTest.Framework.Infrastructure.Filters;
namespace Mc2.CrudTest.Framework.Infrastructure
{
    public class ControllerStartup :IApplicationStartup
    {
        public MiddleWarePriority Priority => MiddleWarePriority.Low;

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
         

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<LogFilterAttribute>();

            IMvcBuilder configController = services.AddControllers(
                option => {
                    option.Filters.Add(typeof(LogFilterAttribute));
                  
                });

          


            configController.ConfigureApiBehaviorOptions((option) =>
            {
                option.ClientErrorMapping[404].Title = "Not Found";
                option.InvalidModelStateResponseFactory = (Context) =>
                {
                    var values = Context.ModelState.Values.Where(state => state.Errors.Count != 0)
                  .Select(state => state.Errors.Select(p => new { errorMessage = p.ErrorMessage }));

                    return new BadRequestObjectResult(values);

                };
            });
        }
    }
}
