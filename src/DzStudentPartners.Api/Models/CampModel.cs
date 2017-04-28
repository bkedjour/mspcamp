using System;
using System.ComponentModel.DataAnnotations;

namespace DzStudentPartners.Api.Models
{
    public class CampModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Tag { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(250)]
        public string Description { get; set; }

        public string LocationAddress1 { get; set; }
        public string LocationAddress2 { get; set; }
        public string LocationWilaya { get; set; }
    }
}