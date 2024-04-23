using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IdentityAuthLesson.Filters
{
    public class CustomResultFilter : Attribute,IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("After action");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var objectResult = context.Result as ObjectResult;

            if (objectResult != null)
            {
                if (objectResult.Value is string str)
                {
                    objectResult.Value = $"{str} - salom Elyor";
                }
            }
        }
    }
}
