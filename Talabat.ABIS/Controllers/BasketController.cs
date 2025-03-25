using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.ABIS.DTOs;
using Talabat.ABIS.Errors;
using Talabat.Core.Entites;
using Talabat.Core.Repositories;

namespace Talabat.ABIS.Controllers
{

    public class BasketController : ApiBaseController
    {
        private readonly IBaskedReopsitory _baskedReopsitory;
        private readonly IMapper _mapper;

        public BasketController(IBaskedReopsitory baskedReopsitory, IMapper mapper)
        {
            _baskedReopsitory = baskedReopsitory;
            _mapper = mapper;
        }



        //Get Or Recreate Basket
        [HttpGet("{Id}")]
        public async Task<ActionResult<Customerbasket>> GetCustomerBasket(string BasketId)
        {

            var Basket = await _baskedReopsitory.GetBasketAsync(BasketId);
            return Basket is null ? new Customerbasket(BasketId) : Ok(Basket);
        }

        //Update Or Create New Basket

        [HttpPost]
        public async Task<ActionResult<Customerbasket>> UpdatOrCreateBasket(CustomerBasketDto Basket)
        {
            var MappedBasket = _mapper.Map<CustomerBasketDto, Customerbasket>(Basket);
            var CreatedOrUpdatedBasket = await _baskedReopsitory.UpdateBasketAsync(MappedBasket);
            if (CreatedOrUpdatedBasket is null) return BadRequest(new ApiResponce(400));
            return Ok(CreatedOrUpdatedBasket);
        }


        //Delet

        [HttpDelete]

        public async Task<ActionResult<bool>> DeleteBasket(string BasketId)
        {
            return await _baskedReopsitory.DeleteBasketAsync(BasketId);
        }

    }
}
