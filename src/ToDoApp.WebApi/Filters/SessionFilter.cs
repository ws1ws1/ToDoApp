using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ToDoApp.WebApi.Filters
{
    public class SessionFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.Session.GetInt32("Session_Id") == null)
            {
                context.Result = new UnauthorizedResult();          
            }
            else
            {
                context.Result = new OkResult();
            }
        }
    }
}
