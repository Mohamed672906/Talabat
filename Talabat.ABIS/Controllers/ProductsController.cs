using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.ABIS.DTOs;
using Talabat.ABIS.Errors;
using Talabat.Core.Entites;
using Talabat.Core.Repositories;
using Talabat.Core.Specifications;

namespace Talabat.ABIS.Controllers
{
  
    public class ProductsController : ApiBaseController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ProductType> _typeRepo;
        private readonly IGenericRepository<ProductBrand> _brandRepo;

        public ProductsController(IGenericRepository<Product> ProductRepo 
          ,IMapper mapper 
          , IGenericRepository<ProductType> TypeRepo
           , IGenericRepository<ProductBrand> BrandRepo )
        {
            _productRepo = ProductRepo;
            _mapper = mapper;
            _typeRepo = TypeRepo;
            _brandRepo = BrandRepo;
        }

        //Get All Products

        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts([FromQuery]ProdctSpecPram Parms)
        {
            var Spec = new ProductWithBrandAndtypeSpecification(Parms);
            var Products = await _productRepo.GetAllWithSpecAsync(Spec);
            var MappedProduct = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(Products);
            return Ok(MappedProduct);

          }

        //Get Product by Id 

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductToReturnDto),200)]
        [ProducesResponseType(typeof(ApiResponce),404)]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var Spec = new ProductWithBrandAndtypeSpecification(id);
            var Products = await _productRepo.GetByIdWithSpecAsync(Spec);
            if(Products is null) return NotFound(new ApiResponce(404));
            var MappedProduct = _mapper.Map<Product, ProductToReturnDto>(Products);
            return Ok(MappedProduct);


        }

        // Get All Type 
        [HttpGet("Type")]

        public async Task<ActionResult<IEnumerable<ProductType>>> GetType()
        {

            var Type = await _typeRepo.GetAllAsync();

             return Ok(Type);
        }

        //Get All Brand 


        [HttpGet("Brand")]

        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetBrand()
        {

            var Brand = await _brandRepo.GetAllAsync();

            return Ok(Brand);

        }

    }
}
