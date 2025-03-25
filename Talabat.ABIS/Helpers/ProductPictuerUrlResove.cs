using System.ComponentModel;
using AutoMapper;
using Talabat.ABIS.DTOs;
using Talabat.Core.Entites;

namespace Talabat.ABIS.Helpers
{
    public class ProductPictuerUrlResove : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProductPictuerUrlResove(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl)) 
            {
                return $"{_configuration["ApiBaseUrl"]}{source.PictureUrl}";
            }
            return String.Empty;
        }

    }
}
