using System.ComponentModel.DataAnnotations;

namespace BusStop.Data.Client
{
    public class ClientDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SecondName { get; set; }
        public int CountOfTravels { get; set; }
    }
}