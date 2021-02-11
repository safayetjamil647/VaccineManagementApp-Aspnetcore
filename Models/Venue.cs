using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicaTeams.Models
{
    public class Venue
    {
        public int VenueId { get; set; }
        public string VenueName { get; set; }

        public string DistrictName { get; set; }

        public string VaccineName { get; set; }

        public int VaccineAmount { get; set; }

        public DateTime StartDate { get; set; }

        public string VolunteerGroup { get; set; }
        
        public int NumberOfVolunteer { get; set; }
        public ICollection<VaccineCandidate> VaccineCandidates { get; set; }
    }
}
