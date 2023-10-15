using Application.Core.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Application.Core.Models
{
    public class Client
    {
        public Guid RecordId { get; set; }
        [Required(ErrorMessage = "Please enter a Client Name")]
        public string ClientName { get; set; }
        [Required(ErrorMessage = "Please enter a Date of registration")]
        [DataType(DataType.Date)]
        [YearRange(1900,2023)]
        public DateTime DateRegistered { get; set; }
        [Required(ErrorMessage = "Please enter a location")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Please enter a number of users per system")]
        [MinimunNumber(1)]
        public int NumberOfSystemUsers { get; set; }

    }



}

