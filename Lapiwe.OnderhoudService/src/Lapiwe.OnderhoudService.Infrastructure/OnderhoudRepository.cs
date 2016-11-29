using Lapiwe.OnderhoudService.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class OnderhoudRepository : IRepository
{
    private DbContextOptions<OnderhoudContext> options;

    public OnderhoudRepository(DbContextOptions<OnderhoudContext> options)
    {
        this.options = options;
    }
}