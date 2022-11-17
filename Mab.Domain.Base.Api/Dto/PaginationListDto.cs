using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mab.Domain.Base.Api.Dto
{
    public class PaginationListDto:IDtoBase
    {
        public static IDtoBase FromList<TItemType>(IEnumerable<TItemType> pageItems, int skip, int take, int totalNumber) where TItemType : IDtoBase
        {
            return new PaginationListDto<TItemType>()
            {
                Items = new DtoList<TItemType>(pageItems),
                TotalNumber = totalNumber,
                Skip = skip,
                Take = take
            };
        }
        public static IDtoBase FromList<TItemType>(IEnumerable<TItemType> pageItems, PaginationDto pagination, int totalNumber) where TItemType : IDtoBase
        {
            return new PaginationListDto<TItemType>()
            {
                Items = new DtoList<TItemType>(pageItems),
                TotalNumber = totalNumber,
                Skip = pagination.Skip,
                Take = pagination.Take
            };
        }

        public int TotalNumber { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }
    }
    public class PaginationListDto<TItemType>: PaginationListDto,IDtoBase where TItemType : IDtoBase
    {
        internal static IDtoBase FromList(IEnumerable<TItemType> pageItems,int skip,int take,int totalNumber)
        {
            return new PaginationListDto<TItemType>()
            {
                Items = new DtoList<TItemType>(pageItems),
                TotalNumber = totalNumber,
                Skip = skip,
                Take = take
            };
        }
        internal static IDtoBase FromList(IEnumerable<TItemType> pageItems,PaginationDto pagination, int totalNumber)
        {
            return new PaginationListDto<TItemType>()
            {
                Items = new DtoList<TItemType>(pageItems),
                TotalNumber = totalNumber,
                Skip = pagination.Skip,
                Take = pagination.Take
            };
        }
        public DtoList<TItemType> Items { get; set; }
       

        
    }
}
