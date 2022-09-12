using Mab.Domain.Base.Api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mab.Domain.Base.Api.Handler
{
    public interface IAsyncApiEndPointHandler<TResponse,TRequest>:IApiEndPoint
    {
        Task<TResponse> HandleAsync(TRequest request);
    }
   
    public interface IAsyncApiEndPointHandler<TResponse>:IApiEndPoint
    {
        Task<TResponse> HandleAsync();
    }
  
}
