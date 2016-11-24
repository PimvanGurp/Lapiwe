
using Lapiwe.GMS.FrontEnd.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lapiwe.GMS.Frontend.DAL
{
    public class LapiweGarageContext : DbContext
    {
        public DbSet<Bestuurder> Bestuurders { get; set; }

        public LapiweGarageContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase();
        }
    }
}