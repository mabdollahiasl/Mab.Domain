using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mab.Domain.Base.Api.Dto
{
    public static class StatusCodeResults
    {
        public static IDtoBase NotFound(string? message = null)
        {
            return new StatusCodeResult(System.Net.HttpStatusCode.NotFound, message);
        }
        public static IDtoBase OK(string? message = null)
        {
            return new StatusCodeResult(System.Net.HttpStatusCode.OK, message);
        }
        public static IDtoBase Unauthorized(string? message = null)
        {
            return new StatusCodeResult(System.Net.HttpStatusCode.Unauthorized, message);
        }
        public static IDtoBase NoContent(string? message = null)
        {
            return new StatusCodeResult(System.Net.HttpStatusCode.NoContent, message);
        }
        public static IDtoBase Forbidden(string? message = null)
        {
            return new StatusCodeResult(System.Net.HttpStatusCode.Forbidden, message);
        }
        public static IDtoBase BadRequest(string? message = null)
        {
            return new StatusCodeResult(System.Net.HttpStatusCode.BadRequest, message);
        }
        public static IDtoBase Accepted(string? message = null)
        {
            return new StatusCodeResult(System.Net.HttpStatusCode.Accepted, message);
        }
        public static IDtoBase NotAcceptable(string? message = null)
        {
            return new StatusCodeResult(System.Net.HttpStatusCode.NotAcceptable, message);
        }
    }
}
