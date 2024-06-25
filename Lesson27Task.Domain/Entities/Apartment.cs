using System.ComponentModel.DataAnnotations;

namespace Lesson27Task.Data.Entities
{
    public class Apartment
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int Number  { get; set; }
        [Required]
        [MaxLength(30)]
        public string Building { get; set; }
        public int Rooms { get; set; }
    }
}
