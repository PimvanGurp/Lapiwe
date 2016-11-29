using Lapiwe.EventBus.Dispatchers;
using Lapiwe.GMS.FrontEnd.DAL;
using Lapiwe.IS.RDW.Export.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lapiwe.GMS.FrontEnd.Dispatchers
{
    public class OnderhoudDispatcher : EventDispatcher
    {
        private FrontendContext _context;

        public OnderhoudDispatcher(FrontendContext context)
        {
            _context = context;
        }

        public void KeuringsVerzoekVerwerktZonderSteekproef(KeuringsVerzoekVerwerktZonderSteekproefEvent domainEvent)
        {
            KeuringsVerzoek verzoek = new KeuringsVerzoek(
                telf    
            );
            // Vind onderhoud
            // Markeer als klaar
        }

        public void KeuringsVerzoekVerwerktMetSteekproef(KeuringsVerzoekVerwerktMetSteekproefEvent domainEvent)
        {
            // Geef steekproef aan op onderhoud
        }
    }
}
