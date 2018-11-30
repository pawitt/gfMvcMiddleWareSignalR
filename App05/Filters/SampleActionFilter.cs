using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class SampleAsyncActionAttribute : ActionFilterAttribute ,IAsyncActionFilter
{
    private readonly string course;
    public SampleAsyncActionAttribute(string course)
    {
        this.course = course;
    }
    public string Description { get; set; } = null;

    public override async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        // do something before the action executes
        var resultContext = await next();
        context.HttpContext.Response.Headers.Add("X-Course",course);
        if (Description!=null)
            context.HttpContext.Response.Headers.Add("X-Description", Description);
        // do something after the action executes; resultContext.Result will be set
    }
}
