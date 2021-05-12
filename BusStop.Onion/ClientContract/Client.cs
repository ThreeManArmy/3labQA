using System.ComponentModel.DataAnnotations;

namespace BusStop.Onion.ClientContract
{
    public class Client
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int CountOfTravels { get; set; }
    }
}