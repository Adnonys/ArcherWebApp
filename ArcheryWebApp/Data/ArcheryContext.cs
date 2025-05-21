using Microsoft.EntityFrameworkCore;
using ArcheryWebApp.Models;

namespace ArcheryWebApp.Data
{
    public class ArcheryContext : DbContext
    {
        public ArcheryContext(DbContextOptions<ArcheryContext> options)
            : base(options) { }

        public DbSet<Score> ScoreTable { get; set; }
        public DbSet<ScoreStaging> ScoreStaging { get; set; }
        public DbSet<Round> RoundTable { get; set; }
        public DbSet<ArcheryWebApp.Models.Range> RangeTable { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Archer> ArcherTable { get; set; }
        public DbSet<Class>    ClassTable    { get; set; }
        public DbSet<Division> DivisionTable { get; set; }

    }
}