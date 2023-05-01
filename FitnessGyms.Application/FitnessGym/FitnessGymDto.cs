using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessGyms.Application.FitnessGym
{
    public class FitnessGymDto
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "Please insert description")]
        public string? Description { get; set; }
        public string? Opinions { get; set; }

        [StringLength(12, MinimumLength = 2)]
        public string? PhoneNumber { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string EncodedName { get;  set; } 
    }
}
