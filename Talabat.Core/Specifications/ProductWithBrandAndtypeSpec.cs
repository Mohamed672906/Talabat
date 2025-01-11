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
        public ProductWithBrandAndtypeSpecification(string Sort):base()
        {
            Includes.Add(P => P.ProductBrand);
            Includes.Add(P => P.ProductType);
            if(! string.IsNullOrEmpty(Sort))
            {
                switch(Sort)
                {
                    case "PriceAsc":
                        AddOrderBy(P=>P.Price);
                        break;
                    case "PriceDes":
                        AddOrderByDescending(P => P.Price);
                        break;
                    default:
                        AddOrderBy(P => P.Name);
                       break;
                        
                }
            }

        }

       // CTOR Is Used For Product By Id 
        public ProductWithBrandAndtypeSpecification(int id ):base(P=>P.Id == id)
        {

            Includes.Add(P => P.ProductBrand);
            Includes.Add(P => P.ProductType);
        }

    }
}
