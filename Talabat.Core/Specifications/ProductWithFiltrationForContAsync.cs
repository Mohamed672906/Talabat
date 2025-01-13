using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites;

namespace Talabat.Core.Specifications
{
    public class ProductWithFiltrationForContAsync : BaseSepecification<Product>
    {

        public ProductWithFiltrationForContAsync(ProdctSpecPram Parms)
             : base(P =>
            (!Parms.BrandId.HasValue || P.ProductBrandId == Parms.BrandId)
            &&
            (!Parms.TypeId.HasValue || P.ProductTypeId == Parms.TypeId)
              )
        {

        }


    }
}
