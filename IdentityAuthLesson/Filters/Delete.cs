using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace IdentityAuthLesson.Filters
{
    public class Delete : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("after action");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                Console.WriteLine($"bu user id edi {userId}");
            }
            return;
        }
    }
}
