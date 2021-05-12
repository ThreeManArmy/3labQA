using System.ComponentModel.DataAnnotations;

namespace BusStop.Data.BusStop
{
    public class BusDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int CountOfBuses { get; set; }
    }
}