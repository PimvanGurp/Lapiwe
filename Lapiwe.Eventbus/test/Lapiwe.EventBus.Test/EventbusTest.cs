using Lapiwe.Common;
using Lapiwe.EventbusClient.Test.CommandHandlers;
using Lapiwe.EventbusClient.Test.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Lapiwe.EventbusClient.Test
{
    [TestClass]
    public class EventbusTest
    {
        [TestMethod]
        public void EventbusCanPublishAndSubscribeACommand()
        {
            // Arrange
            RegistreerKlantCommandHandler handler = new RegistreerKlantCommandHandler();
            RegistreerKlantCommand command = new RegistreerKlantCommand("Elon Musk");

            using (IEventbus eventbus = new Eventbus()) {
                eventbus.Subscribe(handler);
                eventbus.PublishCommand(command);

                Thread.Sleep(10);

                Assert.AreEqual(1, handler.TimesCalled);
            }
        }
    }
}
