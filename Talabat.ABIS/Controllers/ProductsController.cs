using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entites;
using Talabat.Core.Repositories;
using Talabat.Core.Specifications;

namespace Talabat.ABIS.Controllers
{
  
    public class ProductsController : ApiBaseController
    {
        private readonly IGenericRepository<Product> _productRepo;


        public ProductsController(IGenericRepository<Product> ProductRepo)
        {
            _productRepo = ProductRepo;
        }

        //Get All Products

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var Spec = new ProductWithBrandAndtypeSpecification();
            var Products = await _productRepo.GetAllWithSpecAsync(Spec);
            return Ok(Products);
          }

        //Get Product by Id 

        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {

            var Products = await _productRepo.GetByIdAsync(id);
            return Ok(Products);

        }



    }
}
