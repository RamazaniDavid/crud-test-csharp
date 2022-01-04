using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Mc2.CrudTest.Framework.Infrastructure.Filters
{
    public class MyAutorizeAttribute : Attribute, IAsyncAuthorizationFilter
    {
        public string Roles { get; set; }
        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(401);

            }

            if (string.IsNullOrEmpty(Roles))
            {
                return Task.CompletedTask;
            }

            var listroles = Roles.Split(",");

            if (listroles.Count() == 0)
                return Task.CompletedTask;

            var clientrole = context.HttpContext.User.Claims.Where(p => p.Type.Contains("role")).Select(p => p.Value).SingleOrDefault();


            if (string.IsNullOrEmpty(clientrole))
            {
                context.Result = new StatusCodeResult(403);
            }

            if (!string.IsNullOrEmpty(clientrole))
            {
                var clientroles = clientrole.Split(',');
                if (!listroles.Any(role => clientroles.Contains(role)))
                {
                    context.Result = new StatusCodeResult(403);
                }
            }
            return Task.CompletedTask;
        }
    }

}
