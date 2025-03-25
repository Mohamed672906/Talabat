using Microsoft.EntityFrameworkCore.Query;
using Talabat.ABIS.DTOs;

namespace Talabat.ABIS.Helpers
{
    public class Pagination<T>
    {
        private int pagSize;

        public Pagination(int pageIndex, int pagSize, IReadOnlyList<T> data , int count)
        {
            PageIndex = pageIndex;
            this.pagSize = pagSize;
            Data = data; 
            Count=count;
        }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int Count { get; set; }

        public IReadOnlyList<T> Data { get; set; }



    }
}
