using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lapiwe.IS.RDW.Export.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lapiwe.GMS.FrontEnd.Dispatchers;
using Lapiwe.IS.RDW.Export.Events;
using Lapiwe.GMS.FrontEnd.DAL;
using Lapiwe.OnderhoudService.Export;

namespace Lapiwe.GMS.FrontEnd.Stub.Agents
{
    public class OnderhoudAgentStub : IOnderhoudAgent
    {
        private FrontendContext _context;

        public OnderhoudAgentStub(FrontendContext context)
        {
            _context = context;
        }

        public IActionResult Toevoegen(RegisteerOnderhoudOpdrachtCommand command)
        {
            // Simulate an incoming event
            OnderhoudDispatcher dispatcher = new OnderhoudDispatcher(_context);

            OnderhoudsOpdrachtGeregistreerdEvent domainEvent = new OnderhoudsOpdrachtGeregistreerdEvent(
                opdrachtGuid: Guid.NewGuid(),
                klantGuid: command.KlantGuid,
                autoGuid: command.AutoGuid,
                aanmeldDatum: command.AanmeldDatum,
                kilometerstand: command.Kilometerstand,
                opdrachtOmschrijving: command.OpdrachtOmschrijving,
                apk: command.Apk
            );
            dispatcher.OnderhoudsOpdrachtGeregistreerd(domainEvent);

            return new OkResult();
        }
    }
}
