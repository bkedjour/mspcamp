using System.ComponentModel.DataAnnotations;

namespace DzStudentPartners.Api.Models
{
    public class SkillModel
    {
        [Required]
        public string Name { get; set; }
    }
}