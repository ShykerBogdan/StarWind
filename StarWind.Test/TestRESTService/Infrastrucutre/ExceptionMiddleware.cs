using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRESTService.Infrastrucutre    
{

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {                
                 HandleException(httpContext, ex);
            }
        }

        private void HandleException(HttpContext context, Exception exception)
        {
            var requestLog = $"REQUEST HttpMethod: {context.Request.Method} \n" +
                           $"Path: {context.Request.Path} \n" +
                           $"Exception message:{exception.Message}\n" +
                           $"Stack Trace:{exception.StackTrace}\n";
            _logger.LogError(requestLog);
        }
    }
}
