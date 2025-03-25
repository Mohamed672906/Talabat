using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites;

namespace Talabat.Core.Specifications
{
    public class ProductWithBrandAndtypeSpecification : BaseSepecification<Product>
    {
        // CTOR Is Used For Get All Product 
        public ProductWithBrandAndtypeSpecification(ProdctSpecPram Parms)
            : base(P =>
            (string.IsNullOrEmpty(Parms.Search) || P.Name.ToLower().Contains(Parms.Search))
            &&
            (!Parms.BrandId.HasValue || P.ProductBrandId == Parms.BrandId)
            &&
            (!Parms.TypeId.HasValue || P.ProductTypeId == Parms.TypeId)
              )

        {
            Includes.Add(P => P.ProductType);   
            Includes.Add(P => P.ProductBrand);
            if (!string.IsNullOrEmpty(Parms.Sort))
            {
                switch (Parms.Sort)
                {
                    case "PriceAsc":
                        AddOrderBy(P => P.Price);
                        break;
                    case "PriceDes":
                        AddOrderByDescending(P => P.Price);
                        break;
                    default:
                        AddOrderBy(P => P.Name);
                        break;

                }
            }


            ApplyPagination(Parms.PagSize * (Parms.PageIndex - 1), Parms.PagSize);
        }

        // CTOR Is Used For Product By Id 
        public ProductWithBrandAndtypeSpecification(int id) : base(P => P.Id == id)
        {

            Includes.Add(P => P.ProductBrand);
            Includes.Add(P => P.ProductType);
        }

    }
}
