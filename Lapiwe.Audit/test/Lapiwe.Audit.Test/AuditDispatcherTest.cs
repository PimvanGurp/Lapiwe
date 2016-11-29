using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections;
using Lapiwe.Audit.Domain.Contracts;
using Lapiwe.Audit.Domain;
using Lapiwe.Audit.Publisher;
using Lapiwe.Audit.Listener;
using Lapiwe.EventBus.Domain;

namespace Minor.WSA.Audit.Test
{
    [TestClass]
    public class AuditDispatcherTest
    {

        [TestMethod]
        public void AuditDispatcherCallsCorrectMethods()
        {
            // Arrange
            var repoMock = new Mock<IRepository>(MockBehavior.Strict);
            repoMock.Setup(repo => repo.Insert(It.IsAny<SerializedEvent>()));

            var e = new SerializedEvent {Body = "AuditDispatcher.Test", TimeReceived = DateTime.Now };
            repoMock.Setup(repo => repo.FindBy(It.IsAny<Expression<Func<SerializedEvent, bool>>>()))
                    .Returns(() => new List<SerializedEvent>() { e });

            var pubMock = new Mock<IPublisher>(MockBehavior.Strict);
            pubMock.Setup(pub => pub.Publish(It.IsAny<string>(), It.IsAny<SerializedEvent>()));

            var options = new BusOptions { ExchangeName = "TestExchange1", HostName = "Localhost", Port = 5672, Username = "guest", Password = "guest" };

            using (var target = new AuditDispatcher(repoMock.Object, pubMock.Object, options))
            {
                // Act
                var command = new SendAllEventCommand { routingKeyAddress = "Test.QueueName", StartTime = DateTime.MinValue, EndTime = DateTime.MaxValue};
                target.OnReceived(command);

                // Assert
                repoMock.Verify(repo => repo.FindBy(It.IsAny<Expression<Func<SerializedEvent, bool>>>()), Times.Once());
                pubMock.Verify(pub => pub.Publish(It.IsAny<string>(), It.IsAny<SerializedEvent>()), Times.Once());
            }
        }

        [TestMethod]
        public void AuditDispatcherCallsCorrectMethodsCount()
        {
            // Arrange
            var repoMock = new Mock<IRepository>(MockBehavior.Strict);
            repoMock.Setup(repo => repo.Insert(It.IsAny<SerializedEvent>()));

            var e = new SerializedEvent { Body = "AuditDispatcher.Test", TimeReceived = DateTime.Now };
            repoMock.Setup(repo => repo.FindBy(It.IsAny<Expression<Func<SerializedEvent, bool>>>()))
                    .Returns(() => new List<SerializedEvent>() { e, e, e });

            var pubMock = new Mock<IPublisher>(MockBehavior.Strict);
            pubMock.Setup(pub => pub.Publish(It.IsAny<string>(), It.IsAny<SerializedEvent>()));

            var options = new BusOptions { ExchangeName = "TestExchange1", HostName = "Localhost", Port = 5672, Username = "guest", Password = "guest" };

            using (var target = new AuditDispatcher(repoMock.Object, pubMock.Object, options))
            {
                // Act
                var command = new SendAllEventCommand { routingKeyAddress = "Test.QueueName", StartTime = DateTime.MinValue, EndTime = DateTime.MaxValue };
                target.OnReceived(command);

                // Assert
                repoMock.Verify(repo => repo.FindBy(It.IsAny<Expression<Func<SerializedEvent, bool>>>()), Times.Once());
                pubMock.Verify(pub => pub.Publish(It.IsAny<string>(), It.IsAny<SerializedEvent>()), Times.Exactly(3));
            }
        }

        [TestMethod]
        public void AuditDispatcher_isRoutingkeyMatch_correctMatch()
        {
            // Arrange
            var options = new BusOptions { ExchangeName = "TestExchange1", HostName = "Localhost", Port = 5672, Username = "guest", Password = "guest" };

            using (var target = new AuditDispatcher(null, null, options))
            {
                var commandKey = "Test";
                var eventKey = "Test";

                // Act
                var result = target.isRoutingKeyMatch(commandKey, eventKey);

                // Assert
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void AuditDispatcher_isRoutingkeyMatch_IncorrectMatch()
        {
            // Arrange
            var options = new BusOptions { ExchangeName = "TestExchange1", HostName = "Localhost", Port = 5672, Username = "guest", Password = "guest" };

            using (var target = new AuditDispatcher(null, null, options))
            {
                var commandKey = "Test";
                var eventKey = "Mismatch";

                // Act
                var result = target.isRoutingKeyMatch(commandKey, eventKey);

                // Assert
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void AuditDispatcher_isRoutingkeyMatch_correctMatchWithDots()
        {
            // Arrange
            var options = new BusOptions { ExchangeName = "TestExchange1", HostName = "Localhost", Port = 5672, Username = "guest", Password = "guest" };

            using (var target = new AuditDispatcher(null, null, options))
            {
                var commandKey = "Test.test";
                var eventKey = "Test.test";

                // Act
                var result = target.isRoutingKeyMatch(commandKey, eventKey);

                // Assert
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void AuditDispatcher_isRoutingkeyMatch_correctMatchWithStarWildcard()
        {
            // Arrange
            var options = new BusOptions { ExchangeName = "TestExchange1", HostName = "Localhost", Port = 5672, Username = "guest", Password = "guest" };

            using (var target = new AuditDispatcher(null, null, options))
            {
                var commandKey = "Test.*";
                var eventKey = "Test.test";

                // Act
                var result = target.isRoutingKeyMatch(commandKey, eventKey);

                // Assert
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void AuditDispatcher_isRoutingkeyMatch_correctMatchWithStarWildcardAndTrailingText()
        {
            // Arrange
            var options = new BusOptions { ExchangeName = "TestExchange1", HostName = "Localhost", Port = 5672, Username = "guest", Password = "guest" };

            using (var target = new AuditDispatcher(null, null, options))
            {
                var commandKey = "Test.*.event";
                var eventKey = "Test.test.event";

                // Act
                var result = target.isRoutingKeyMatch(commandKey, eventKey);

                // Assert
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void AuditDispatcher_isRoutingkeyMatch_IncorrectMatchWithStarWildcardAndTrailingText()
        {
            // Arrange
            var options = new BusOptions { ExchangeName = "TestExchange1", HostName = "Localhost", Port = 5672, Username = "guest", Password = "guest" };

            using (var target = new AuditDispatcher(null, null, options))
            {
                var commandKey = "Test.*.fail";
                var eventKey = "Test.test.event";

                // Act
                var result = target.isRoutingKeyMatch(commandKey, eventKey);

                // Assert
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void AuditDispatcher_isRoutingkeyMatch_IncorrectMatchWithStarWildcardMultipleLevels()
        {
            // Arrange
            var options = new BusOptions { ExchangeName = "TestExchange1", HostName = "Localhost", Port = 5672, Username = "guest", Password = "guest" };

            using (var target = new AuditDispatcher(null, null, options))
            {
                var commandKey = "Test.*.event";
                var eventKey = "Test.test.anothertest.event";

                // Act
                var result = target.isRoutingKeyMatch(commandKey, eventKey);

                // Assert
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void AuditDispatcher_isRoutingkeyMatch_CorrectMatchWithHashWildcard()
        {
            // Arrange
            var options = new BusOptions { ExchangeName = "TestExchange1", HostName = "Localhost", Port = 5672, Username = "guest", Password = "guest" };

            using (var target = new AuditDispatcher(null, null, options))
            {
                var commandKey = "#";
                var eventKey = "Test";

                // Act
                var result = target.isRoutingKeyMatch(commandKey, eventKey);

                // Assert
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void AuditDispatcher_isRoutingkeyMatch_CorrectMatchWithHashWildcardTwoLevels()
        {
            // Arrange
            var options = new BusOptions { ExchangeName = "TestExchange1", HostName = "Localhost", Port = 5672, Username = "guest", Password = "guest" };

            using (var target = new AuditDispatcher(null, null, options))
            {
                var commandKey = "#";
                var eventKey = "Test.test";

                // Act
                var result = target.isRoutingKeyMatch(commandKey, eventKey);

                // Assert
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void AuditDispatcher_isRoutingkeyMatch_CorrectMatchWithHashWildcardThreeLevels()
        {
            // Arrange
            var options = new BusOptions { ExchangeName = "TestExchange1", HostName = "Localhost", Port = 5672, Username = "guest", Password = "guest" };

            using (var target = new AuditDispatcher(null, null, options))
            {
                var commandKey = "#";
                var eventKey = "Test.test.test";

                // Act
                var result = target.isRoutingKeyMatch(commandKey, eventKey);

                // Assert
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void AuditDispatcher_isRoutingkeyMatch_CorrectMatchWithHashWildcardThreeLevelsWithLeadingText()
        {
            // Arrange
            var options = new BusOptions { ExchangeName = "TestExchange1", HostName = "Localhost", Port = 5672, Username = "guest", Password = "guest" };

            using (var target = new AuditDispatcher(null, null, options))
            {
                var commandKey = "Test.#";
                var eventKey = "Test.test.test";

                // Act
                var result = target.isRoutingKeyMatch(commandKey, eventKey);

                // Assert
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void AuditDispatcher_isRoutingkeyMatch_CorrectMatchWithHashWildcardFourLevelsWithLeadingAndTrailingText()
        {
            // Arrange
            var options = new BusOptions { ExchangeName = "TestExchange1", HostName = "Localhost", Port = 5672, Username = "guest", Password = "guest" };

            using (var target = new AuditDispatcher(null, null, options))
            {
                var commandKey = "Test.#.Event";
                var eventKey = "Test.test.tEst.Event";

                // Act
                var result = target.isRoutingKeyMatch(commandKey, eventKey);

                // Assert
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void AuditDispatcher_isRoutingkeyMatch_IncorrectMatchWithHashWildcardThreeLevelsWithLeadingText()
        {
            // Arrange
            var options = new BusOptions { ExchangeName = "TestExchange1", HostName = "Localhost", Port = 5672, Username = "guest", Password = "guest" };

            using (var target = new AuditDispatcher(null, null, options))
            {
                var commandKey = "Eventbus.#";
                var eventKey = "Test.test.test";

                // Act
                var result = target.isRoutingKeyMatch(commandKey, eventKey);

                // Assert
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void AuditDispatcher_isRoutingkeyMatch_IncorrectMatchWithHashWildcardThreeLevelsWithTrailingText()
        {
            // Arrange
            var options = new BusOptions { ExchangeName = "TestExchange1", HostName = "Localhost", Port = 5672, Username = "guest", Password = "guest" };

            using (var target = new AuditDispatcher(null, null, options))
            {
                var commandKey = "Test.#.event";
                var eventKey = "Test.test.test";

                // Act
                var result = target.isRoutingKeyMatch(commandKey, eventKey);

                // Assert
                Assert.IsFalse(result);
            }
        }


    }
}
