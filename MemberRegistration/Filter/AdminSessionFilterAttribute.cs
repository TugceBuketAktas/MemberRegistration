using MemberRegistration.Data.Models;
using MemberRegistration.Extention;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MemberRegistration.Filter
{
    public class AdminSessionFilterAttribute :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session.Get<Users>("Oturum");

            if(session == null)
            {
                context.HttpContext.Response.Redirect("/Login/Index");
            }
            else
            {
                if (session.UserPermission == false)
                {
                    context.HttpContext.Response.WriteAsync("Only admin members can view this page.");
                }
            }

        }
    }
}
