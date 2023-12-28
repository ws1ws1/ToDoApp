using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ToDoApp.WebApi.Filters
{
    public class SessionFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.Session.GetString("session_data") == null)
            {
                context.Result = new UnauthorizedResult();          
            }
            else
            {
                await next();
            }
        }
    }
}
