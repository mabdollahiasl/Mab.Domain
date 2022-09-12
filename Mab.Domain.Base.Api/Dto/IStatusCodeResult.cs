using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mab.Domain.Base.Api.Dto
{
    public interface IStatusCodeResult:IDtoBase
    {
        HttpStatusCode StatusCode { get; set; }
        string? Message { get; set; }
    }
}
