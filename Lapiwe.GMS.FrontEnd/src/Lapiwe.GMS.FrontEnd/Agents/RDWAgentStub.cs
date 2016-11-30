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

namespace Lapiwe.GMS.FrontEnd.Agents
{
    public class RDWAgentStub : IRDWAgent
    {
        private FrontendContext _context;

        public RDWAgentStub(FrontendContext context)
        {
            _context = context;
        }

        public IActionResult KeuringsVerzoek(KeuringsVerzoekCommand domainCommand)
        {
            // Simulate an incoming event
            OnderhoudDispatcher dispatcher = new OnderhoudDispatcher(_context);

            Random random = new Random();

            if (random.Next(0, 2) == 0)
            {
                KeuringVerwerktMetSteekproefEvent domainEvent = new KeuringVerwerktMetSteekproefEvent();
                domainEvent.OnderhoudsGuid = Guid.NewGuid();
                dispatcher.KeuringsVerzoekVerwerktMetSteekproef(domainEvent);
            } else
            {
                KeuringVerwerktZonderSteekproefEvent domainEvent = new KeuringVerwerktZonderSteekproefEvent();
                domainEvent.OnderhoudsGuid = Guid.NewGuid();
                dispatcher.KeuringsVerzoekVerwerktZonderSteekproef(domainEvent);
            }

            return new OkResult();
        }
    }
}
