using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Talabat.ABIS.DTOs;
using Talabat.Core.Entites;
using Talabat.Core.Entites.Identity;

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


            CreateMap<Address, AddressDto>().ReverseMap();

            CreateMap<CustomerBasketDto, Customerbasket>();

            CreateMap<BasketitemDto, BasketItem>();

        }



    }
}
