using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MozaeekCore.Core.ResponseMessages;
using MozaeekCore.Exceptions;

namespace MozaeekCore.RestAPI.Utility
{
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result != null && context.Controller.ToString() != "MozaeekCore.RestAPI.Controllers.ErrorController")
            {
                if (context.Result is ObjectResult objectResult)
                {
                    objectResult.Value = new Result { Data = objectResult.Value };
                }
            }
            // else
            // {
            //     // Problem()
            //     //if (context.Exception is UserFriendlyException exp)
            //     //{
            //     //    context.Result = new BadRequestObjectResult(new Result()
            //     //    {
            //     //        Error = new ErrorMessage() { Message = exp.Message },
            //     //    });
            //
            //     //    // context.Result = new ObjectResult(new Result()
            //     //    // {
            //     //    //     Error = new ErrorMessage() { Message = context.Exception.Message },
            //     //    // });
            //     //    //context.Response = new HttpResponseMessage()
            //     //    //{
            //     //    //    StatusCode = HttpStatusCode.Unauthorized,
            //     //    //    Content = new StringContent("Unauthorized User")
            //     //    //};
            //     //    // (context.Result as ObjectResult)?.StatusCode = 500;
            //     //}
            // }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }

}