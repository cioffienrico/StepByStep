using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using Serilog;
using System.IO;
using System.Net;
using System.Threading.Tasks;

using System;
using StepByStep.Infrastructure;
using StepByStep.Domain;
using Gcsb.Connect.Pkg.Startup.Webapi.Resources;

namespace Gcsb.Connect.Fines.Webapi.Pipeline
{
    public class ErrorHandlerMiddleware
    {
        private readonly IWebHostEnvironment env;
        private readonly IStringLocalizer<ReturnMessages> localization;

        public ErrorHandlerMiddleware(IWebHostEnvironment env, IStringLocalizer<ReturnMessages> localization)
        {
            this.env = env;
            this.localization = localization;
        }

        public async Task Invoke(HttpContext context)
        {
            var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;

            Log.Information("Problem Details Request: {Body}", context.Response.ToString());

            if (ex == null)
            {
                return;
            }

            var model = new ProblemDetails
            {
                Detail = ex.Message
            };

            if (ex is ApplicationException || ex is DomainException || ex is InfrastructureException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                model.Title = $"{localization["ServerError"]}: {ex.Message}";                
            }
            else if (ex is ArgumentOutOfRangeException)
            {
                context.Response.StatusCode = 404;
                model.Title = $"{localization[ex.GetType().Name]}: {ex.Message}";
            }
            else if (ex is NullReferenceException || ex is ArgumentException)
            {
                context.Response.StatusCode = 400;
                model.Title = $"{localization[ex.GetType().Name]}: {ex.Message}";
            }                     
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                model.Title = localization["ServerError"];               
            }
            
            if (env.IsDevelopment())
            {                
                model.Detail += $"{ex.GetType()}: {ex.Message}: {ex.StackTrace}";
            }

            context.Response.ContentType = "application/json";
            using (var writer = new StreamWriter(context.Response.Body))
            {
                new JsonSerializer().Serialize(writer, model);
                await writer.FlushAsync().ConfigureAwait(false);
            }
        }
    }
}
