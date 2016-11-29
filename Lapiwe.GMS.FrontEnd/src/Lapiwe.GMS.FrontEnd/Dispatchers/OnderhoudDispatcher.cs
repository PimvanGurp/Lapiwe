using Lapiwe.EventBus.Dispatchers;
using Lapiwe.GMS.FrontEnd.DAL;
using Lapiwe.GMS.FrontEnd.Entities;
using Lapiwe.IS.RDW.Export.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lapiwe.GMS.FrontEnd.Dispatchers
{
    public class OnderhoudDispatcher
    {
        private FrontendContext _context;

        public OnderhoudDispatcher(FrontendContext context)
        {
            _context = context;
        }

        public void KeuringsVerzoekVerwerktZonderSteekproef(KeuringVerwerktZonderSteekproefEvent domainEvent)
        {
            KeuringsVerzoek verzoek = new KeuringsVerzoek(domainEvent.OnderhoudsGuid, true);

            _context.KeuringsVerzoeken.Add(verzoek);
            _context.SaveChanges();
        }

        public void KeuringsVerzoekVerwerktMetSteekproef(KeuringVerwerktMetSteekproefEvent domainEvent)
        {
            KeuringsVerzoek verzoek = new KeuringsVerzoek(domainEvent.OnderhoudsGuid, false);

            _context.KeuringsVerzoeken.Add(verzoek);
            _context.SaveChanges();
        }
    }
}
