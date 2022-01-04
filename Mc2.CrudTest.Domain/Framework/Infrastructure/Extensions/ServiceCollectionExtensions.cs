using Mc2.CrudTest.Core.Infrastructure;
using Mc2.CrudTest.Core.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Mc2.CrudTest.Core.Extensions;

namespace Mc2.CrudTest.Framework.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var listTypes = typeof(IApplicationStartup).GetAllClassTypes();

            List<IApplicationStartup> listObjects = new List<IApplicationStartup>();

            foreach (var typeitem in listTypes)
            {
                var ob = Activator.CreateInstance(typeitem) as IApplicationStartup;
                listObjects.Add(ob);
            }

            foreach (var item in listObjects.OrderBy(p=>p.Priority))
            {
                item.ConfigureServices(services, configuration);
            }


            var listTaskTypes = typeof(ITaskSchduler).GetAllClassTypes();
            foreach (var typeTask in listTaskTypes)
            {
                services.AddScoped(typeTask);
            }
        }
    }

}
