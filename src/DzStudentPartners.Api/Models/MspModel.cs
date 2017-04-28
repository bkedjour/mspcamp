using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DzStudentPartners.Api.Models
{
    public class MspModel
    {
        [Required]
        public string Name { get; set; }

        public string Twitter { get; set; }

        public string Region { get; set; }

        public string University { get; set; }

        public int Rank { get; set; }

        public double Points { get; set; }

        public ICollection<SkillModel> Skills { get; set; }
    }
}