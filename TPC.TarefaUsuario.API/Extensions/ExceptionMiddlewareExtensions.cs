using Microsoft.AspNetCore.Diagnostics;
using TPC.TarefaUsuario.API.Core.Data.Entity.Error;
using TPC.TarefaUsuario.API.Core.Services.Exception;
using System.Collections.ObjectModel;
using System.Net;

namespace TPC.TarefaUsuario.API.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/problem+json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var inner = contextFeature?.Error;

                        while (inner?.InnerException != null)
                        {
                            inner = inner.InnerException;
                        }

                        if (inner != null && inner is ServiceException && ((ServiceException)inner)?.Problem != null)
                        {
                            context.Response.StatusCode = ((ServiceException)inner).Problem.Status;
                            ((ServiceException)inner).Problem.Instance = context.Request.Path;
                            ((ServiceException)inner).Problem.TraceId = Guid.NewGuid().ToString();
                            ((ServiceException)inner).Problem.Method = context.Request.Method;


                            await context.Response.WriteAsync(((ServiceException)inner).Problem.ToString());
                        }
                        else
                            {
                                Problem problema = new Problem()
                                {
                                    Status = context.Response.StatusCode,
                                    Title = "Internal Server Error.",
                                    Instance = context.Request.Path,
                                    Type = "internalError",
                                    TraceId = Guid.NewGuid().ToString(),
                                    Method = context.Request.Method,
                                    Detail = contextFeature?.Error?.Message,
                                    InnerException = contextFeature?.Error?.InnerException
                                };


                                await context.Response.WriteAsync(problema.ToString());
                            }


                    }
                });
            });
        }
    }
}
