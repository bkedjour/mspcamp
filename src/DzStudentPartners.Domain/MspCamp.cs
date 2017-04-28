using System;
using System.Collections.Generic;

namespace DzStudentPartners.Domain
{
    public class MspCamp
    {
        public int Id { get; set; }

        public string Tag { get; set;}

        public string Name { get; set; }

        public DateTime EventDate { get; set; } = DateTime.MinValue;

        public string Description { get; set; }

        public Location Location { get; set; }

        public ICollection<Msp> Msps { get; set; }
    }
}