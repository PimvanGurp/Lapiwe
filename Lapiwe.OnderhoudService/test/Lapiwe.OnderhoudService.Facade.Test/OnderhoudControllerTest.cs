using Lapiwe.Common.Infastructure;
using Lapiwe.OnderhoudService.Facade.Controllers;
using Lapiwe.OnderhoudService.Infrastructure;
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
        public void MyTestMethod()
        {
            var repoMock = new Mock<IRepository>(MockBehavior.Strict);

            var pubMock = new Mock<IEventPublisher>(MockBehavior.Strict);

            var target = new OnderhoudController(repoMock.Object, pubMock.Object);



        }
    }
}
