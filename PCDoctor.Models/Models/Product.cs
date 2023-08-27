using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        public string? ImageUrl { get; set; }

       


    }
}
