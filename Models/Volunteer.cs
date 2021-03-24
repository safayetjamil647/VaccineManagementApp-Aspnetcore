using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicaTeams.Models
{
    public class Volunteer
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
    }
}
