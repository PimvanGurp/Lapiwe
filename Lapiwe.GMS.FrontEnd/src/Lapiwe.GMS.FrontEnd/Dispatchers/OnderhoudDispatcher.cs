using Lapiwe.EventBus.Dispatchers;
using Lapiwe.GMS.FrontEnd.DAL;
using Lapiwe.GMS.FrontEnd.Stub.Entities;
using Lapiwe.IS.RDW.Export.Events;
using Lapiwe.OnderhoudService.Export;
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

        public void OnderhoudsOpdrachtGeregistreerd(OnderhoudsOpdrachtGeregistreerdEvent domainEvent)
        {
            OnderhoudsOpdracht onderhoudsOpdracht = new OnderhoudsOpdracht
            {
                Apk = domainEvent.Apk,
                AanmeldDatum = domainEvent.AanmeldDatum,
                Kilometerstand = domainEvent.Kilometerstand,
                OpdrachtOmschrijving = domainEvent.OpdrachtOmschrijving
            };

            _context.OnderhoudsOpdrachten.Add(onderhoudsOpdracht);
            _context.SaveChanges();
        }
    }
}
