using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Filters
{
    public class MyActionFilter : IActionFilter
    {
        private readonly ILogger logger;

        public MyActionFilter(ILogger<MyActionFilter> logger)
        {
            this.logger = logger;
        }

        // before
        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogWarning("OnActionExecuting");
        }

        // after
        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogWarning("OnActionExecuted");
        }

    }
}
