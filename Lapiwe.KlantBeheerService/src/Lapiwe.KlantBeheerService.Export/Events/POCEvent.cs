using Minor.WSA.Common.Domain;

namespace Lapiwe.KlantBeheerService.Export.Events
{
    public class POCEvent : DomainEvent
    {
        public string Message { get; private set; }

        public POCEvent(string message)
        {
            Message = message;
        }
    }
}