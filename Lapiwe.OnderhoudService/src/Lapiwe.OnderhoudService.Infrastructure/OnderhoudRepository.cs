using System;
using Lapiwe.OnderhoudService.Domain;
using Lapiwe.OnderhoudService.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class OnderhoudRepository : IRepository
{
    private DbContextOptions<OnderhoudContext> options;

    public OnderhoudRepository(DbContextOptions<OnderhoudContext> options)
    {
        this.options = options;
    }

    public void Insert(OnderhoudsOpdracht opdracht)
    {
        using(var context = new OnderhoudContext(options))
        {
            context.OnderhoudsOpdrachten.Add(opdracht);
            context.SaveChanges();
        }
    }
}