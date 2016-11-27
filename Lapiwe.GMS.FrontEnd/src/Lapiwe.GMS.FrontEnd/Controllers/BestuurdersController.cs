using Lapiwe.Common;
using Lapiwe.GMS.Frontend.DAL;
using Lapiwe.GMS.FrontEnd.Entities;
using Lapiwe.GMS.FrontEnd.Export.Commands;
using Lapiwe.GMS.FrontEnd.ViewModels;
using Lapiwe.KlantBeheerService.Export.Commands;
using Lapiwe.KlantBeheerService.Export.Entities;
using Microsoft.AspNetCore.Mvc;
using RawRabbit.Configuration.Exchange;
using RawRabbit.vNext;
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
            var busClient = BusClientFactory.CreateDefault();
            var command = new RegistreerKlantCommand(new Klant());
            busClient.PublishAsync(command, command.CorrelationID, (config) => {
                config.WithExchange((exchange) =>
                {
                    exchange.WithName("Lapiwe.Eventbus.Default");
                    exchange.WithType(ExchangeType.Topic);
                });
                config.WithRoutingKey("Lapiwe.FE.RegistreerKlantCommand");
            });

            //_context.Klanten.Add(klant);
            //_context.SaveChanges();

            return RedirectToAction("BestuurdersOverzicht");
        }
    }
}
