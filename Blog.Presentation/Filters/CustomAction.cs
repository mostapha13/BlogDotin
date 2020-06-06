using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace Blog.Presentation.Filters
{
    public class CustomAction:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Log.Information($"StartAction: {context.ActionDescriptor.DisplayName}");
         
        }


        public override void OnActionExecuted(ActionExecutedContext context)
        {
           Log.Information($"EndAction: {context.ActionDescriptor.DisplayName}");
        }
    }
}
