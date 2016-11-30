using Lapiwe.Common.Infastructure;
using Lapiwe.OnderhoudService.Domain;
using Lapiwe.OnderhoudService.Export;
using Lapiwe.OnderhoudService.Facade.Controllers;
using Lapiwe.OnderhoudService.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lapiwe.OnderhoudService.Facade.Test
{
    [TestClass]
    public class OnderhoudControllerTest
    {

        [TestMethod]
        public void OnderhoudControllerPostFails()
        {
            // Arrange
            var repoMock = new Mock<IRepository>(MockBehavior.Strict);
            var pubMock = new Mock<IEventPublisher>(MockBehavior.Strict);
            var target = new OnderhoudController(repoMock.Object, pubMock.Object);

            // Act
            IActionResult result = target.Post(null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void OnderhoudControllerPostSuccess()
        {
            // Arrange
            var repoMock = new Mock<IRepository>(MockBehavior.Strict);
            repoMock.Setup(r => r.Insert(It.IsAny<OnderhoudsOpdracht>()));

            var pubMock = new Mock<IEventPublisher>(MockBehavior.Strict);
            pubMock.Setup(p => p.Publish(It.IsAny<OnderhoudsOpdrachtGeregistreerdEvent>()));

            var target = new OnderhoudController(repoMock.Object, pubMock.Object);

            var command = new RegisteerOnderhoudOpdrachtCommand();

            // Act
            IActionResult result = target.Post(command);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
