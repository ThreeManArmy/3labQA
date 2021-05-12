using System.ComponentModel.DataAnnotations;

namespace BusStop.Onion.BusContract
{
    public class Bus
    {
        [Required]
        public int Id { get; set; }
        public string Location { get; set; }
        public int CountOfBuses { get; set; }
    }
}