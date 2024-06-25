using System.ComponentModel.DataAnnotations;

namespace Lesson27Task.Data.Entities
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [MaxLength(35)]
        public string ProductName { get; set; }
        public int Price { get; set; }
        [MaxLength(20)]
        public string Brand { get; set; }
    }
}
