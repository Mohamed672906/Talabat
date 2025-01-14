using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.ABIS.Errors;
using Talabat.Core.Entites;
using Talabat.Core.Repositories;

namespace Talabat.ABIS.Controllers
{

    public class BasketController : ApiBaseController
    {
        private readonly IBaskedReopsitory _baskedReopsitory;

        public BasketController(IBaskedReopsitory baskedReopsitory)
        {
            _baskedReopsitory = baskedReopsitory;
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
        public async Task<ActionResult<Customerbasket>> UpdateBasket(Customerbasket Basket)
        {
            var CreatedOrUpdatedBasket = await _baskedReopsitory.UpdateBasketAsync(Basket);
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
