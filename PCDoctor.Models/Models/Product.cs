using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PCDoctor.Models.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Product Name")]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [DisplayName("Manufacturer")]
        public string? Manufacturer { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
