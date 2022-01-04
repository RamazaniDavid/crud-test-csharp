using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Framework.Infrastructure.Filters
{
    public class LogFilterAttribute : Attribute, IActionFilter, IAsyncActionFilter
    {
        private readonly ILogger<LogFilterAttribute> _logger;

        public LogFilterAttribute(ILogger<LogFilterAttribute> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _logger.LogInformation("Action " + context.ActionDescriptor.DisplayName + " is Executing ");
            _logger.LogInformation("Action " + context.ActionDescriptor.DisplayName + "  Executed ");
            await Task.CompletedTask;
        }
    }
}