using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entites;
using Talabat.Core.Repositories;

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

        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {

            var Products =await _productRepo.GetAllAsync();
            return Ok(Products);


        }







        //Get Product by Id 






    }
}
