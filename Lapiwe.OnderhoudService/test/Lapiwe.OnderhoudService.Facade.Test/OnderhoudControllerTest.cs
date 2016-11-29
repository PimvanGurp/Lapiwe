using Lapiwe.Common.Infastructure;
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
        public void OnderhoudControllerPostSuccess()
        {
            var repoMock = new Mock<IRepository>(MockBehavior.Strict);

            var pubMock = new Mock<IEventPublisher>(MockBehavior.Strict);

            var target = new OnderhoudController(repoMock.Object, pubMock.Object);

            var command = new RegisteerOnderhoudOpdrachtCommand();
            IActionResult result = target.Post(command);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void OnderhoudControllerPostFails()
        {
            var repoMock = new Mock<IRepository>(MockBehavior.Strict);

            var pubMock = new Mock<IEventPublisher>(MockBehavior.Strict);

            var target = new OnderhoudController(repoMock.Object, pubMock.Object);

            IActionResult result = target.Post(null);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }
    }
}
