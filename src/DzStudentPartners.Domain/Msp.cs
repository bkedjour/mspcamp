using System.Collections.Generic;

namespace DzStudentPartners.Domain
{
    public class Msp
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Twitter { get; set; }

        public string Region { get; set; }

        public string University { get; set; }

        public int Rank { get; set; }

        public double Points { get; set; }

        public MspCamp Camp { get; set; }

        public ICollection<Skill> Skills { get; set; }
    }
}