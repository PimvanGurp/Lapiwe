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
        private IOnderhoudAgent _agent;

        public OnderhoudController(IOnderhoudAgent agent)
        {
            _agent = agent;
        }

        [HttpGet]
        public IActionResult AutoKlaarmeldenOverzicht()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MeldAutoKlaar(string voorletter, string achternaam, string kenteken, string kilometerstand)
        {
            string volledigeNaam = $"{voorletter}. {achternaam}";

            _agent.MeldAutoKlaar(volledigeNaam, kenteken, int.Parse(kilometerstand));

            return View();
        }
    }
}
