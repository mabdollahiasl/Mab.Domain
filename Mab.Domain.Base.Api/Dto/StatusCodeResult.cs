using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mab.Domain.Base.Api.Dto
{
    public class StatusCodeResult:IStatusCodeResult
    {
       

        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
        public StatusCodeResult(HttpStatusCode statuscode, string? message)
        {
            StatusCode = statuscode;
            Message = message;
        }
    }
}
