using Mc2.CrudTest.Core.Infrastructure;
using Mc2.CrudTest.Core.Tasks;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using Mc2.CrudTest.Core.Extensions;


namespace Mc2.CrudTest.Framework.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureRequestPipeline(this IApplicationBuilder application)
        {
            var listTypes = typeof(IApplicationStartup).GetAllClassTypes();


            List<IApplicationStartup> listObjects = new List<IApplicationStartup>();

            foreach (var typeitem in listTypes)
            {
                var ob = Activator.CreateInstance(typeitem) as IApplicationStartup;
                listObjects.Add(ob);
            }

            foreach (var item in listObjects.OrderBy(p => p.Priority))
            {
                item.Configure(application);
            }

            var listTaskTypes = typeof(ITaskSchduler).GetAllClassTypes();
            foreach (var typeTask in listTaskTypes)
            {
                var task = application.ApplicationServices.GetService(typeTask) as ITaskSchduler;
                if (task!.IsActiveInStartup)
                    task.ExecuteTask();

            }

        }
    }

}
