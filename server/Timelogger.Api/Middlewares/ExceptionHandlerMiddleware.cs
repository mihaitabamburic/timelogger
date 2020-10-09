using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Timelogger.Api
{
  public class ExceptionHandlerMiddleware
  {
    private readonly RequestDelegate next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
      this.next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
      try
      {
        await next(httpContext);
      }
      catch (BadHttpRequestException e)
      {
        await HandleBadHttpRequestExceptionAsync(httpContext, e);
      }
      catch (Exception e)
      {
        await HandleException(httpContext, e);
      }
    }

    private Task HandleBadHttpRequestExceptionAsync(HttpContext httpContext, BadHttpRequestException e)
    {
      httpContext.Response.ContentType = "application/json";
      httpContext.Response.StatusCode = (int)e.StatusCode;

      return httpContext.Response.WriteAsync(e.Message);
    }

    private Task HandleException(HttpContext httpContext, Exception e)
    {
      httpContext.Response.ContentType = "application/json";
      httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

      return httpContext.Response.WriteAsync("Your request cannot be processed at this time");
    }
  }
}