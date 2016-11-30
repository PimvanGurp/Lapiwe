using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lapiwe.OnderhoudService.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Lapiwe.OnderhoudService.Infrastructure.Test
{

    [TestClass]
    public class RepositoryTest
    {

        private static DbContextOptions<OnderhoudContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<OnderhoudContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }


        [TestMethod]
        public void Repository_InsertAddsItem()
        {
            // Arrange
            var options = CreateNewContextOptions();
            IRepository target = new OnderhoudRepository(options);

            var opdracht = new OnderhoudsOpdracht() { };

            // Act
            target.Insert(opdracht);

            // Assert
            using (var context = new OnderhoudContext(options))
            {
                Assert.AreEqual(1, context.OnderhoudsOpdrachten.Count());
            }

        }

        [TestMethod]
        public void Repository_InsertAddsFiveItems()
        {
            // Arrange
            var options = CreateNewContextOptions();
            IRepository target = new OnderhoudRepository(options);

            var opdracht1 = new OnderhoudsOpdracht() { };
            var opdracht2 = new OnderhoudsOpdracht() { };
            var opdracht3 = new OnderhoudsOpdracht() { };
            var opdracht4 = new OnderhoudsOpdracht() { };
            var opdracht5 = new OnderhoudsOpdracht() { };

            // Act
            target.Insert(opdracht1);
            target.Insert(opdracht2);
            target.Insert(opdracht3);
            target.Insert(opdracht4);
            target.Insert(opdracht5);

            // Assert
            using (var context = new OnderhoudContext(options))
            {
                Assert.AreEqual(5, context.OnderhoudsOpdrachten.Count());
            }

        }


    }
}
