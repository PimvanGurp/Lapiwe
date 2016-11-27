using Lapiwe.Common;
using System;

namespace Lapiwe.KlantBeheerService.Export.Events
{
    public class KlantGeregistreerdEvent : DomainEvent
    {
        public Guid KlantId { get; set; }

        public KlantGeregistreerdEvent(Guid klantId)
        {
            KlantId = klantId;
        }
    }
}
