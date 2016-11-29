using Lapiwe.OnderhoudService.Domain;
using Microsoft.EntityFrameworkCore;

public class OnderhoudContext : DbContext
{

    public OnderhoudContext(DbContextOptions<OnderhoudContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<OnderhoudsOpdracht> OnderhoudsOpdrachten { get; set; }
}