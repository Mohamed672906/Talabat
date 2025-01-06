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
        public ProductWithBrandAndtypeSpecification()
        {
            Includes.Add(P => P.ProductBrand);
            Includes.Add(P => P.ProductType);

        }

       // CTOR Is Used For Product By Id 
        public ProductWithBrandAndtypeSpecification(int id ):base(P=>P.Id == id)
        {

            Includes.Add(P => P.ProductBrand);
            Includes.Add(P => P.ProductType);
        }

    }
}
