using Lapiwe.Common.Infastructure;
using Lapiwe.GMS.FrontEnd.Stub.Agents;
using Lapiwe.GMS.FrontEnd.DAL;
using Lapiwe.GMS.FrontEnd.Stub.Entities;
using Lapiwe.GMS.FrontEnd.ViewModels;
using Lapiwe.IS.RDW.Export.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lapiwe.OnderhoudService.Export;

namespace Lapiwe.GMS.FrontEnd.Controllers
{
    public class OnderhoudsOpdrachtenController : Controller
    {
        private FrontendContext _context;
        private IOnderhoudAgent _agent;

        public OnderhoudsOpdrachtenController(IOnderhoudAgent agent, FrontendContext context)
        {
            _agent = agent;
            _context = context;
        }

        [HttpGet]
        public IActionResult Invullen()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Toevoegen(string klantnaam, string kenteken, int kilometerstand, string opdrachtomschrijving, bool apk)
        {
            RegisteerOnderhoudOpdrachtCommand command = new RegisteerOnderhoudOpdrachtCommand(
                klantGuid: Guid.NewGuid(),
                autoGuid: Guid.NewGuid(),
                aanmeldDatum: DateTime.Now,
                kilometerstand: kilometerstand,
                opdrachtOmschrijving: opdrachtomschrijving,
                apk: apk
            );

            _agent.Toevoegen(command);

            return RedirectToAction("Overzicht");
        }

        [HttpGet]
        public IActionResult Overzicht()
        {
            IEnumerable<OnderhoudsOpdracht> onderhoudsOpdrachten = _context.OnderhoudsOpdrachten.ToList();

            OnderhoudsOpdrachtenViewModel model = new OnderhoudsOpdrachtenViewModel(onderhoudsOpdrachten);

            return View(model);
        }
    }
}
