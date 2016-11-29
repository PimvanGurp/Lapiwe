using Lapiwe.Common.Infastructure;
using Lapiwe.GMS.FrontEnd.Agents;
using Lapiwe.GMS.FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lapiwe.GMS.FrontEnd.Controllers
{
    public class OnderhoudController : Controller
    {
        private IRDWAgent _agent;

        public OnderhoudController(IRDWAgent agent)
        {
            _agent = agent;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KeuringsVerzoek(string voornaam, string tussenvoegsel, string achternaam, string kenteken, string kilometerstand)
        {
            string volledigeNaam = $"{voornaam.First()}. {tussenvoegsel} {achternaam}";

            //KeuringsVerzoekCommand command = new KeuringsVerzoekCommand(volledigeNaam, kenteken, kilometerstand);

            _agent.KeuringsVerzoek(null /*command*/);

            return View();
        }
    }
}
