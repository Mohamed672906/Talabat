using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entites;
using Talabat.Core.Entites.Order;

namespace Talabat.Repository.Data
{
    public class StoreContext : DbContext
    {

        public StoreContext(DbContextOptions<StoreContext> options):base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }




        public DbSet<Product> products { get; set; }

        public DbSet<ProductType> productTypes { get; set; }

        public DbSet<ProductBrand> productBrands { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethod { get; set; }


    }
}
 