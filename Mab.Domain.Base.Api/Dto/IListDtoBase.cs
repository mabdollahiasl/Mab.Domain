using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mab.Domain.Base.Api.Dto
{
    public interface IListDtoBase<out T> : IEnumerable<T>, IDtoBase where T : IDtoBase
    {

    }
    public class DtoList<T> : List<T>, IListDtoBase<T> where T : IDtoBase
    {
        public DtoList()
        {
        }

        public DtoList(IEnumerable<T> collection) : base(collection)
        {
        }

        public DtoList(int capacity) : base(capacity)
        {
        }

    }
}
