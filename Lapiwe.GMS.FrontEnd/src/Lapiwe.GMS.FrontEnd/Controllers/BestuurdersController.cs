using Lapiwe.Common;
using Lapiwe.GMS.Frontend.DAL;
using Lapiwe.GMS.FrontEnd.Entities;
using Lapiwe.GMS.FrontEnd.Export.Commands;
using Lapiwe.GMS.FrontEnd.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Lapiwe.GMS.FrontEnd.Controllers
{
    public class BestuurdersController : Controller
    {
        private LapiweGarageContext _context;
        private IEventbus _eventbus;

        public BestuurdersController(LapiweGarageContext context, IEventbus eventbus)
        {
            _context  = context;
            _eventbus = eventbus;
        }

        public IActionResult RegistratieOverzicht()
        {
            return View();
        }

        public IActionResult BestuurdersOverzicht()
        {
            IEnumerable<Bestuurder> bestuurders = _context.Bestuurders.ToList();
            BestuurdersLijstViewModel alleBestuurders = new BestuurdersLijstViewModel(bestuurders);

            return View(alleBestuurders);
        }

        [HttpPost]
        public IActionResult RegistreerBestuurder(Bestuurder bestuurder)
        {
            _eventbus.PublishCommand(new RegistreerBestuurderCommand(bestuurder));

            _context.Bestuurders.Add(bestuurder);
            _context.SaveChanges();

            return RedirectToAction("BestuurdersOverzicht");
        }
    }
}
