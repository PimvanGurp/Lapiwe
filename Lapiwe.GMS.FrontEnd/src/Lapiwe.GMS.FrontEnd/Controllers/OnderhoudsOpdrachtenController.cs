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
        private ISimpleRepository _repository;
        private IOnderhoudAgent _agent;

        public OnderhoudsOpdrachtenController(IOnderhoudAgent agent, ISimpleRepository repository)
        {
            _agent = agent;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Invullen()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Toevoegen(
            string klantnaam, string telefoonnummer, string kenteken, 
            int kilometerstand, string opdrachtomschrijving, bool apk
        ) {
            Auto auto = new Auto(kenteken, kilometerstand);
            Klant klant = new Klant(klantnaam, telefoonnummer);

            RegisteerOnderhoudOpdrachtCommand command = new RegisteerOnderhoudOpdrachtCommand(
                klantGuid: klant.Guid,
                autoGuid: auto.Guid,
                aanmeldDatum: DateTime.Now,
                kilometerstand: kilometerstand,
                opdrachtOmschrijving: opdrachtomschrijving,
                apk: apk
            );

            _repository.Add(auto);
            _repository.Add(klant);
            _agent.Toevoegen(command);

            return RedirectToAction("Overzicht");
        }

        [HttpGet]
        public IActionResult Overzicht()
        {
            IEnumerable<OnderhoudsOpdracht> onderhoudsOpdrachten = _repository.FindAll<OnderhoudsOpdracht>();

            OnderhoudsOpdrachtenViewModel model = new OnderhoudsOpdrachtenViewModel(onderhoudsOpdrachten);

            return View(model);
        }
    }
}
