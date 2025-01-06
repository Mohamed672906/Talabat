using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.ABIS.DTOs;
using Talabat.Core.Entites;
using Talabat.Core.Repositories;
using Talabat.Core.Specifications;

namespace Talabat.ABIS.Controllers
{
  
    public class ProductsController : ApiBaseController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> ProductRepo ,IMapper mapper)
        {
            _productRepo = ProductRepo;
            _mapper = mapper;
        }

        //Get All Products

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var Spec = new ProductWithBrandAndtypeSpecification();
            var Products = await _productRepo.GetAllWithSpecAsync(Spec);
            var MappedProduct = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturnDto>>(Products);
            return Ok(MappedProduct);

          }

        //Get Product by Id 

        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var Spec = new ProductWithBrandAndtypeSpecification(id);
            var Products = await _productRepo.GetByIdWithSpecAsync(Spec);
            var MappedProduct = _mapper.Map<Product, ProductToReturnDto>(Products);
            return Ok(MappedProduct);


        }



    }
}
