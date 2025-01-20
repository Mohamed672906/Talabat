using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.ABIS.DTOs;
using Talabat.ABIS.Errors;
using Talabat.Core.Entites.Order;
using Talabat.Core.Service;
using Talabat.Core;

namespace Talabat.ABIS.Controllers
{

    public class OrdersController : ApiBaseController
    {


        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(IOrderService orderService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _orderService = orderService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }




        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponce), StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email);
            var MappedAddress = _mapper.Map<AddressDto, Address>(orderDto.ShippingAddress);
            var Order = await _orderService.CreateOrderAsync(buyerEmail, orderDto.BasketId, orderDto.DeliveryMethodId, MappedAddress);
            if (Order is null) return BadRequest(new ApiResponce(400, "There is a Problem With Your Order"));
            return Ok(Order);
        }




        [ProducesResponseType(typeof(IReadOnlyList<OrderToReturnDTOs>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<IReadOnlyList<OrderToReturnDTOs>>> GetOrderForUser()
        {
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email);
            var Orders = await _orderService.GetOrdersForSpecificUserAsync(buyerEmail);
            if (Orders is null) return NotFound(new ApiResponce(404, "There is no Orders For This User"));
            var MappedOrders = _mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderToReturnDTOs>>(Orders);

            return Ok(MappedOrders);
        }



        [ProducesResponseType(typeof(OrderToReturnDTOs), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponce), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<OrderToReturnDTOs>> GetOrderByIdForUser(int id)
        {
            var user = User.FindFirstValue(ClaimTypes.Email);
            var result = await _orderService.GetOrderByIdForSpecificUserAsync(user, id);
            if (result is null) return NotFound(new ApiResponce(404, $"There is No Order With Id = {id} For This User"));
            var MappedOrders = _mapper.Map<Order, OrderToReturnDTOs>(result);
            return Ok(MappedOrders);
        }



        [HttpGet("DeliveryMethods")] //GET : url /api/orders/deliveryMethods
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
        {
            var DeliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetAllAsync();
            return Ok(DeliveryMethod);
        }


    }
}
