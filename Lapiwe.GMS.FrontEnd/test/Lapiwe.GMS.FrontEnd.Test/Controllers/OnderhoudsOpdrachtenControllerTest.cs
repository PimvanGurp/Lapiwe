using Lapiwe.GMS.FrontEnd.Controllers;
using Lapiwe.GMS.FrontEnd.DAL;
using Lapiwe.GMS.FrontEnd.Stub.Agents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lapiwe.GMS.FrontEnd.Test.Controllers
{
    [TestClass]
    public class OnderhoudsOpdrachtenControllerTest
    {
        [TestMethod]
        public void OnderhoudsControllerCanBeInstantiated()
        {
            // Arrange
            var agent = new Mock<IOnderhoudAgent>(MockBehavior.Strict);
            var repository = new Mock<ISimpleRepository>(MockBehavior.Strict);
            OnderhoudsOpdrachtenController controller = new OnderhoudsOpdrachtenController(agent.Object, repository.Object);

            // Assert
            Assert.IsInstanceOfType(controller, typeof(Controller));
        }

        [TestMethod]
        public void InvullenReturnsAViewResult()
        {
            // Arrange
            var agent = new Mock<IOnderhoudAgent>(MockBehavior.Strict);
            var repository = new Mock<ISimpleRepository>(MockBehavior.Strict);
            OnderhoudsOpdrachtenController controller = new OnderhoudsOpdrachtenController(agent.Object, repository.Object);

            // Act
            IActionResult result = controller.Invullen();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void ToevoegenReturnsARedirectToAction()
        {
            // Arrange
            var agent = new Mock<IOnderhoudAgent>(MockBehavior.Loose);
            var repository = new Mock<ISimpleRepository>(MockBehavior.Loose);
            OnderhoudsOpdrachtenController controller = new OnderhoudsOpdrachtenController(agent.Object, repository.Object);

            // Act
            IActionResult result = controller.Toevoegen("", "", "", 0, "", false);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void OverzichtReturnsAViewResult()
        {
            // Arrange
            var agent = new Mock<IOnderhoudAgent>(MockBehavior.Loose);
            var repository = new Mock<ISimpleRepository>(MockBehavior.Loose);
            OnderhoudsOpdrachtenController controller = new OnderhoudsOpdrachtenController(agent.Object, repository.Object);

            // Act
            IActionResult result = controller.Overzicht();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
