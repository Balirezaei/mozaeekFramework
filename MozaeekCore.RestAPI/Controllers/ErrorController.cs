using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using MozaeekCore.Core.ResponseMessages;
using MozaeekCore.Exceptions;

namespace MozaeekCore.RestAPI.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public Result ErrorLocalDevelopment(
            [FromServices] IWebHostEnvironment webHostEnvironment)
        {

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error; // Your exception
            var code = 500; // Internal Server Error by default

            if (exception is NotFoundUserFriendlyException) code = 404; // Not Found
            else if (exception is UnAuthorizedUserFriendlyException) code = 401;
            // Unauthorized
            // else if (exception is MyException) code = 400; // Bad Request
            //
            Response.StatusCode = code; // You can use HttpStatusCode enum instead
            var message = exception.Message;
            if (exception.InnerException != null)
            {
                message += "\n " + exception.InnerException.Message;
            }

            if (exception.InnerException != null && exception.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE"))
            {
                message = "امکان حذف این مورد وجود ندارد.";
            }

            var result = new Result()
            {
                Error = new ErrorMessage()
                {
                    Message = message
                }
            };
            return result;

        }

        //[Route("/error")]
        //public IActionResult Error() => Problem();
    }
}
