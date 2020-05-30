using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Serilog;

namespace Blog.Presentation.Middleware
{
    public class ErrorHandling
    {
        private readonly RequestDelegate next;
        public ErrorHandling(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var statusCode = context.Response.StatusCode;
                await HandleExceptionAsync(context, ex);
            }
        }


        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
           
            var result = JsonConvert.SerializeObject(
                new
                { 
                    source=ex.Source,
                    error = ex.Message
                });
            context.Response.ContentType = "application/json";
            

            Log.ForContext("Message", ex.Message)
                 
                .Error($"Error: {result}");

            return context.Response.WriteAsync(result);
        }

    }
}
