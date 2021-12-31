using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Framwork.Infrastructure.Filters
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

            var Clientrole = context.HttpContext.User.Claims.Where(p => p.Type.Contains("role")).Select(p => p.Value).SingleOrDefault();


            if (string.IsNullOrEmpty(Clientrole))
            {
                context.Result = new StatusCodeResult(403);
            }

            if (!string.IsNullOrEmpty(Clientrole))
            {
                var Clientroles = Clientrole.Split(',');
                if (!listroles.Any(role => Clientroles.Contains(role)))
                {
                    context.Result = new StatusCodeResult(403);
                }
            }
            return Task.CompletedTask;
        }
    }

}
