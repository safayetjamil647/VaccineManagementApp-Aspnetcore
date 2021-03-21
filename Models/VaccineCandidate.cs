using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicaTeams.Models
{
    public class VaccineCandidate
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }
        public int Age { get; set; }
        [Required]
        [RegularExpression(@"^+880"),StringLength(12, MinimumLength = 11)]
        public string PhoneNumber { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime VaccineDate { get; set; }
        public string Abnormalities { get; set; }
        public int VenueId { get; set; }
        public Venue Venue { get; set; }


    }
}
