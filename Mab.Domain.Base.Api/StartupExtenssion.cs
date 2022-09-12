using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore;
using Mab.Domain.Base.Api.StatusCodeHandler;

namespace Mab.Domain.Base.Api
{
    public static class StartupExtenssion
    {
        public static void UseStatusCodeHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<StatusCodeMiddleware>();
        }
    }
}
