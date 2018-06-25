using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Loja.Domain;

namespace Loja.Web.Filters{

    public class CustomExceptionFilter: ExceptionFilterAttribute{
        public override void OnException(ExceptionContext context){
            bool isAjacCall = context.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";

            if(isAjacCall){
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = 500;
                var message = context.Exception is DomainException? context.Exception.Message : "An error ocorred";
                context.Result = new JsonResult(message);
                context.ExceptionHandled = true;
            }

            base.OnException(context);
        }
    }
}