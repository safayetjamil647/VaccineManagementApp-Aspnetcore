using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicaTeams.Models
{
    public class VaccineCandidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime VaccineDate { get; set; }
        public string Abnormalities { get; set; }
        public int VenueId { get; set; }
        public Venue Venue { get; set; }


    }
}
