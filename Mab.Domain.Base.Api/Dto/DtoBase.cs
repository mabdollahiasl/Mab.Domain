using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mab.Domain.Base.Api.Dto
{
    public class DtoBase:IDtoBase
    {
        public static IDtoBase FromList<T>(IEnumerable<T> list) where T : IDtoBase
        {
            return new DtoList<T>(list);
        }
    }
}
