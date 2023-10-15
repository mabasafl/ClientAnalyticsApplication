using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Core.Models
{
    public class Client
    {
        public Guid RecordId { get; set; }
        [Required]
        public string ClientName { get; set; }
        public DateTime DateRegisterd { get; set; }
        public string Location { get; set; }
        public int NumberOfSystemUsers { get; set; }
    }
}
