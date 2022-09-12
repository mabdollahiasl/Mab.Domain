using Mab.Domain.Base.Api.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Mab.Domain.Base.Api.StatusCodeHandler
{
    public class StatusCodeMiddleware
    {
        private readonly RequestDelegate _next;
        public StatusCodeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            return InvokeAsync(context);
        }

        private async Task InvokeAsync(HttpContext context)
        {
            try
            {

                Stream originalBody = context.Response.Body;
                using var memStream = new MemoryStream();
                context.Response.Body = memStream;
                await _next(context);
                if (context.Response.ContentType!=null &&
                    context.Response.ContentType.Contains("application/json"))
                {
                    SetStatusCode(context, memStream);
                }
                memStream.Position = 0;
                await memStream.CopyToAsync(originalBody);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SetStatusCode(HttpContext context, Stream bodyStream)
        {
            try
            {
                bodyStream.Position = 0;
                var body = JsonObject.Parse(bodyStream);
                bodyStream.Position = 0;
                var statuscode = body["statusCode"];
                if (statuscode != null)
                {
                    context.Response.StatusCode = int.Parse(statuscode.ToString());
                }
            }
            catch (Exception)
            {
                return;
            }
         
        }
    }
}
