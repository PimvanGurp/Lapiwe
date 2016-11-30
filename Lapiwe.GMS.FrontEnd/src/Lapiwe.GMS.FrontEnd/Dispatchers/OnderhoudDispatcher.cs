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
        private ISimpleRepository _repository;

        public OnderhoudDispatcher(ISimpleRepository repository)
        {
            _repository = repository;
        }

        public void KeuringsVerzoekVerwerktZonderSteekproef(KeuringVerwerktZonderSteekproefEvent domainEvent)
        {
            KeuringsVerzoek verzoek = new KeuringsVerzoek(domainEvent.OnderhoudsGuid, true);

            _repository.Add(verzoek);
        }

        public void KeuringsVerzoekVerwerktMetSteekproef(KeuringVerwerktMetSteekproefEvent domainEvent)
        {
            KeuringsVerzoek verzoek = new KeuringsVerzoek(domainEvent.OnderhoudsGuid, false);

            _repository.Add(verzoek);
        }

        public void OnderhoudsOpdrachtGeregistreerd(OnderhoudsOpdrachtGeregistreerdEvent domainEvent)
        {
            OnderhoudsOpdracht onderhoudsOpdracht = new OnderhoudsOpdracht(
                domainEvent.OnderhoudsOpdrachtGuid,
                _repository.Find<Klant>(domainEvent.KlantGuid),
                _repository.Find<Auto>(domainEvent.AutoGuid),
                domainEvent.OpdrachtOmschrijving
            );
            onderhoudsOpdracht.Apk = domainEvent.Apk;

            _repository.Add(onderhoudsOpdracht);
        }
    }
}
