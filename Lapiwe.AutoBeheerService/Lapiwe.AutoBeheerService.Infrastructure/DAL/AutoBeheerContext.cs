using Lapiwe.KlantBeheerService.Export.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lapiwe.GMS.Frontend.DAL
{
    public class AutoBeheerContext : DbContext
    {
        public DbSet<Auto> autos { get; set; }

        public AutoBeheerContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}