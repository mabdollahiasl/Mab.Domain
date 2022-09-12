using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mab.Domain.Base.Api.Dto
{
    public class PaginationDto:IDtoBase
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public string? Search { get; set; }
    }
}
