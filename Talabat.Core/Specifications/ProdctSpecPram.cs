using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Specifications
{
    public class ProdctSpecPram
    {
        public string? Sort { get; set; }
        public int? BrandId { get; set;  }
        public int? TypeId { get; set; }

        private int pagSize = default;

        public int PagSize
        {
            get { return pagSize; }
            set { pagSize = value>10 ? 10 :value; }
        }

        public int PageIndex { get; set; } = 1;







    }
}
