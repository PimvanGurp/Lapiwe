using Lapiwe.Common;
using Lapiwe.GMS.Frontend.DAL;
using Lapiwe.KlantBeheerService.Export.Entities;
using Lapiwe.KlantBeheerService.Export.Events;
using RawRabbit;
using RawRabbit.vNext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lapiwe.GMS.FrontEnd.EventHandlers
{
    public class KlantGeregistreerdEventHandler : IEventHandler<KlantGeregistreerdEvent>
    {
        private LapiweGarageContext _context;

        public KlantGeregistreerdEventHandler(LapiweGarageContext context)
        {
            _context = context;
        }

        public async Task Handle(KlantGeregistreerdEvent domainEvent)
        {
            Klant klant = _context.Klanten.FirstOrDefault(k => k.Id == domainEvent.KlantId);
            klant?.MarkProcessed();
            klant.Telefoonnummer = "Test succeeded";
            _context.SaveChanges();
        }
    }
}
