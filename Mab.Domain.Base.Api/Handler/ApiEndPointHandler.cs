using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mab.Domain.Base.Api.Handler
{
    [ApiController]
    public abstract class ApiEndPointHandler<TResponse, TRequest> : ControllerBase, IApiEndPoint<TResponse, TRequest>
    {
        public abstract TResponse Handle(TRequest request);
    }
    [ApiController]
    public abstract class ApiEndPointHandler<TResponse> : ControllerBase, IApiEndPoint<TResponse>
    {
        public abstract TResponse Handle();
    }
}
