using Mc2.CrudTest.Core.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mc2.CrudTest.Framework.Infrastructure
{
    public class CommonStartup : IApplicationStartup
    {
        public MiddleWarePriority Priority => MiddleWarePriority.Normal;
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public void Configure(IApplicationBuilder app)
        {
            IWebHostEnvironment env= app.ApplicationServices.GetService(typeof(IWebHostEnvironment)) as IWebHostEnvironment;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(app =>
                {
                    app.UseMiddleware<ErrorHandlerMiddleware>();
                });
                app.UseHsts();

            }
            app.UseCors(MyAllowSpecificOrigins);
            app.UseSwagger();
            // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));
            app.UseSwaggerUI(c =>
            {

                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MC2 CRUD Test API V1");
            });
            app.UseMiddleware<PoweredByMiddleware>();


          

        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped<IErrorHandler, ErrorHandler>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MC2 CRUD Test", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                                  });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Version = "Version 1",
                    Title = "MC2 CRUD Test ",
                    Description = "Just For Test ",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Ramazani David",
                        Email = "Ramazani.david.job@gmail.com",
                        Url = new Uri("https://www.ramazani.david.info"),
                    },
                });
            });

        }
    }
}
