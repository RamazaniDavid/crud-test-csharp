using Mc2.CrudTest.Core.Extenstions;
using Mc2.CrudTest.Core.Infrastructure;
using Mc2.CrudTest.Core.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Mc2.CrudTest.Framework.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var ListTypes = typeof(IApplicationStartup).GetAllClassTypes();

            List<IApplicationStartup> ListObjects = new List<IApplicationStartup>();

            foreach (var Typeitem in ListTypes)
            {
                var ob = Activator.CreateInstance(Typeitem) as IApplicationStartup;
                ListObjects.Add(ob);
            }

            foreach (var item in ListObjects.OrderBy(p=>p.Priority))
            {
                item.ConfigureServices(services, configuration);
            }


            var ListTaskTypes = typeof(ITaskSchduler).GetAllClassTypes();
            foreach (var typeTask in ListTaskTypes)
            {
                services.AddScoped(typeTask);
            }
        }
    }

}
