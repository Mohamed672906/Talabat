using AutoMapper;
using AutoMapper.Execution;
using Talabat.ABIS.DTOs;
using Talabat.Core.Entites.Order;

namespace Talabat.ABIS.Helpers
{
    public class OrderItemUrlPictureResolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        private readonly IConfiguration _configuration;

        public OrderItemUrlPictureResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {

            if (!string.IsNullOrEmpty(source.product.PictureUrl))
            {
                return $"{_configuration["ApiBaseUrl"]}{source.product.PictureUrl}";
            }
            return string.Empty;
        }
    }
}
