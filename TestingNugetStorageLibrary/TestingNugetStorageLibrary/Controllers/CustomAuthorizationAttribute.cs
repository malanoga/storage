using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace TestingNugetStorageLibrary.Controllers
{
    internal class CustomAuthorizationAttribute : ActionFilterAttribute
    {

        string customKey = Environment.GetEnvironmentVariable("CUSTOM_API_KEY") ?? "customApiAuthorization";
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            //var ctx = context.HttpContext.Request.Headers;
            if (!context.HttpContext.Request.Headers.ContainsKey("CustomApiKey"))
            {
                Console.WriteLine("Unathorized");
                context.Result = new UnauthorizedObjectResult("Unauthorized - missing CustomApiKey");

            }
            else
            {
                if (context.HttpContext.Request.Headers["CustomApiKey"].ToString() != customKey)
                {
                    Console.WriteLine("Unathorized");
                    context.Result = new UnauthorizedObjectResult("Unauthorized - CustomApiKey not as requested");

                }
            }
        }
        public override void OnActionExecuted(ActionExecutedContext
                                              context)
        {
            var result = context.Result;
            // Do something with Result.
            if (context.Canceled == true)
            {
                // Action execution was short-circuited by another filter.
            }
            if (context.Exception != null)
            {
                // Exception thrown by action or action filter.
                // Set to null to handle the exception.
                context.Exception = null;
            }
            base.OnActionExecuted(context);
        }
    }
}