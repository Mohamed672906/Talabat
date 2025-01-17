using System.ComponentModel.DataAnnotations;

namespace Talabat.ABIS.DTOs
{
    public class CustomerBasketDto
    {
        [Required]
        public string Id { get; set; }

        public List<BasketitemDto> Items { get; set; }

    }
}
