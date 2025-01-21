using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Talabat.ABIS.DTOs;
using Talabat.Core.Entites;
using Talabat.Core.Entites.Identity;
using Talabat.Core.Entites.Order;

namespace Talabat.ABIS.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                      .ForMember(d => d.ProductType, O => O.MapFrom(S => S.ProductType.Name))
                      .ForMember(d => d.ProductBrand, O => O.MapFrom(S => S.ProductBrand.Name))
                      .ForMember(d => d.PictureUrl, O => O.MapFrom<ProductPictuerUrlResove>());


            //  IMappingExpression<AddressDto, Address> mappingExpression = CreateMap<Address, AddressDto>().ReverseMap();

            CreateMap<CustomerBasketDto, Customerbasket>();

            CreateMap<BasketitemDto, BasketItem>();
            CreateMap<AddressDto, Core.Entites.Order.Address>();
            CreateMap<Core.Entites.Identity.Address, AddressDto>();
            CreateMap<Order, OrderToReturnDTOs>()
                .ForMember(D => D.DeliveryMethod, O => O.MapFrom(S => S.DeliveryMethod.ShortName))
                .ForMember(D => D.DeliveryMethodCost, O => O.MapFrom(S => S.DeliveryMethod.Cost));


            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, O => O.MapFrom(S => S.product.ProductId))
                .ForMember(d => d.ProductName, O => O.MapFrom(S => S.product.ProductName))
                .ForMember(d => d.PictureUrl, O => O.MapFrom(S => S.product.PictureUrl))
                .ForMember(d => d.PictureUrl, O => O.MapFrom<OrderItemUrlPictureResolver>());
;





        }



    }
}
