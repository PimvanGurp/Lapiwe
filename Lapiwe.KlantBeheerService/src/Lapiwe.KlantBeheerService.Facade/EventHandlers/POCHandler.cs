using System;
using Minor.WSA.Common.Contracts;
using Lapiwe.KlantBeheerService.Export.Events;

namespace Lapiwe.KlantBeheerService.Facade.EventHandlers
{
    public class POCHandler : IEventHandler<POCEvent>
    {
        public void Handle(POCEvent domainEvent)
        {
            Console.WriteLine("Proof of Concept: " + domainEvent.Message);
        }
    }
}