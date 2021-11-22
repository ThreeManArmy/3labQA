using System.ComponentModel.DataAnnotations;

namespace BusStop.Orchestrators.BusStop
{
    public class UpdateCount
    {
        [Required]
        public int Count { get; set; }
    }
}