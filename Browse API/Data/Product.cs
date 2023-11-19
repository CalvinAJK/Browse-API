using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Browse_API.Data
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public int Stock {  get; set; }
    }
}
