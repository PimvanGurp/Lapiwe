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

namespace Lapiwe.GMS.FrontEnd.Controllers
{
    public class KeuringsVerzoekController : Controller
    {
        private IRDWAgent _agent;
        private ISimpleRepository _repository;

        public KeuringsVerzoekController(IRDWAgent agent, ISimpleRepository repository)
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
        public IActionResult Toevoegen(string voornaam, string tussenvoegsel, string achternaam, string kenteken, int kilometerstand)
        {
            string volledigeNaam = $"{voornaam.FirstOrDefault()}. {tussenvoegsel} {achternaam}";

            _agent.KeuringsVerzoek(new KeuringsVerzoekCommand() {
                Kenteken = kenteken,
                Klantnaam = volledigeNaam,
                Kilometerstand = kilometerstand,
                OnderhoudsGuid = Guid.NewGuid()
            });

            return RedirectToAction("Overzicht");
        }

        [HttpGet]
        public IActionResult Overzicht()
        {
            IEnumerable<KeuringsVerzoek> verzoeken = _repository.FindAll<KeuringsVerzoek>();

            KeuringsVerzoekenViewModel model = new KeuringsVerzoekenViewModel(verzoeken);

            return View(model);
        }
    }
}
