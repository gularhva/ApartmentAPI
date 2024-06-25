using System.ComponentModel.DataAnnotations;

namespace Lesson27Task.DTO
{
    public class ApartmentDTO
    {
        public int Number { get; set; }
        public string Building { get; set; }
        public int Rooms { get; set; }
    }
}
