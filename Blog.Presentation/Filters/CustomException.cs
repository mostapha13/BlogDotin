using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace Blog.Presentation.Filters
{
    public class CustomException:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {

            context.Result = new StatusCodeResult(500);

            Log.ForContext("Message", context.HttpContext.Items["functionName"])
                    .ForContext("Error",context.HttpContext.Response.StatusCode)
                    .Error($"Error: {context.Exception.Message}");
               

        }


         
    }
}
