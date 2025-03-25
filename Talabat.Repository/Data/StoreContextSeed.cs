using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entites;
using Talabat.Core.Entites.Order;

namespace Talabat.Repository.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext dbcontext)
        {

            if (!dbcontext.productBrands.Any())
            {
                var BrandData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/brands.json");

                var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandData);

                if (Brands?.Count > 0)
                {
                    foreach (var Brand in Brands)
                    {

                        await dbcontext.Set<ProductBrand>().AddAsync(Brand);

                    }
                    await dbcontext.SaveChangesAsync();
                }
            }

            //-----------

            if (!dbcontext.productTypes.Any())
            {
                var TypeData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/types.json");

                var Types = JsonSerializer.Deserialize<List<ProductType>>(TypeData);

                if (Types?.Count > 0)
                {

                    foreach (var Type in Types)
                    {
                        await dbcontext.Set<ProductType>().AddAsync(Type);
                    }
                    await dbcontext.SaveChangesAsync();
                }
            }

            //------------

            if (!dbcontext.products.Any())
            {

                var ProductData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/products.json");

                var Products = JsonSerializer.Deserialize<List<Product>>(ProductData);


                if (Products?.Count > 0)
                {

                    foreach (var product in Products)
                    {


                        await dbcontext.Set<Product>().AddAsync(product);
                    }

                    await dbcontext.SaveChangesAsync();

                }


            };

            //-----

            if (!dbcontext.DeliveryMethod.Any())
            {

                var DeliveryMethodData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/Delivery.json");

                var DeliveryMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(DeliveryMethodData);


                if (DeliveryMethods?.Count > 0)
                {

                    foreach (var DeliveryMethod in DeliveryMethods)
                    {
                        await dbcontext.Set<DeliveryMethod>().AddAsync(DeliveryMethod);
                    }

                    await dbcontext.SaveChangesAsync();

                }


            };


        }
    }
}
