using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mab.Domain.Base.Api.Handler
{
    [ApiController]
    public abstract class AsyncApiEndPointHandler<TResponse, TRequest> : ControllerBase, IAsyncApiEndPointHandler<TResponse, TRequest>
    {
        public abstract Task<TResponse> HandleAsync(TRequest request);
    }
    [ApiController]
    public abstract class AsyncApiEndPointHandler<TResponse> : ControllerBase, IAsyncApiEndPointHandler<TResponse>
    {
        public abstract Task<TResponse> HandleAsync();
    }
}
