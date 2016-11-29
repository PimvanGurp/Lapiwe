using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lapiwe.GMS.FrontEnd.ViewModels;
using MySQL.Data.Entity.Extensions;
using Lapiwe.GMS.FrontEnd.Entities;

namespace Lapiwe.GMS.FrontEnd.DAL
{
    public class FrontendContext : DbContext
    {
        //public DbSet<Onderhoud> onderhoudOpdrachten { get; set; }

        public FrontendContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"server=db;userid=admin;password=1234;database=frontend;");
        }
    }
}
