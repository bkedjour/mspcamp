using DzStudentPartners.Domain;
using Microsoft.EntityFrameworkCore;

namespace DzStudentPartners.Data
{
    public class MspContext : DbContext
    {
        public MspContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<MspCamp> Camps { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Msp> Msps { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
