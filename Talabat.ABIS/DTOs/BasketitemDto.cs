using System.ComponentModel.DataAnnotations;

namespace Talabat.ABIS.DTOs
{
    public class BasketitemDto
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [Range(1, int.MaxValue , ErrorMessage ="Quantity Must be One Item Al least")]
        public int Quantity { get; set; }
        [Required]
        [Range(0.1 ,double.MaxValue, ErrorMessage = " Price Can not Be Zero")]
        public decimal Price { get; set; }



    }
}