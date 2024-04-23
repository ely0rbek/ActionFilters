using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IdentityAuthLesson.Filters
{
    public class CustomResourseFilter : Attribute, IResourceFilter
    {

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("Bu actiondan keyingi holat");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Response.Headers["Cache-Control"] = "public, max-age=600";
        }
    }
}
