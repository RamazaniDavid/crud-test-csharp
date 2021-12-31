using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Framework.Infrastructure
{
    public class PoweredByMiddleware
    {
        private readonly RequestDelegate _next;
        public PoweredByMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            httpContext.Response.Headers["X-Powered-By"] = "Ramazani David";
            return _next.Invoke(httpContext);
        }
    }

}
