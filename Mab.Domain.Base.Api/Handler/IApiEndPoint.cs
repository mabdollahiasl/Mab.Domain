using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mab.Domain.Base.Api.Handler
{
    public interface IApiEndPoint<TResponse, TRequest>:IApiEndPoint
    {
        TResponse Handle(TRequest request);
    }
    public interface IApiEndPoint<TResponse>:IApiEndPoint
    {
        TResponse Handle();
    }
    public interface IApiEndPoint
    {
    }
}
