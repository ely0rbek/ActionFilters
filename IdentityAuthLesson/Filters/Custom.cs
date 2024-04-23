using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IdentityAuthLesson.Filters
{
    public class Custom : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!IsAuthorized(context.HttpContext.User))
            {
                Console.WriteLine("register qil jigar");
                context.Result = new UnauthorizedResult();
                return;
            }
        }
        private bool IsAuthorized(ClaimsPrincipal user)
        {
            var isAuthenticated = user.Identity.IsAuthenticated;
            if(isAuthenticated)
            {
                return true;
            }
            return false; 
        }
    }
}
