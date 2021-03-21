using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicaTeams.Models
{
    public class Venue
    {
        public int VenueId { get; set; }
        [Required]
        public string VenueName { get; set; }
        [Required]
        public string DistrictName { get; set; }
        [Required]
        public string VaccineName { get; set; }

        public int VaccineAmount { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        public string VolunteerGroup { get; set; }
        
        public int NumberOfVolunteer { get; set; }
        public ICollection<VaccineCandidate> VaccineCandidates { get; set; }
    }
}
