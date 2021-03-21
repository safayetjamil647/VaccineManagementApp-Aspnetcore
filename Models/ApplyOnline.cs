using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicaTeams.Models
{
    public class ApplyOnline
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"),StringLength(12, MinimumLength = 11)]
        public string PhoneNumber { get; set; }
        
        public int Age { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime PreferedDate { get; set; }
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Abnormalities { get; set; }
    }
}
