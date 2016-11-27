using Lapiwe.Common;
using Lapiwe.GMS.Frontend.DAL;
using Lapiwe.GMS.FrontEnd.ViewModels;
using Lapiwe.KlantBeheerService.Export.Commands;
using Lapiwe.KlantBeheerService.Export.Entities;
using Microsoft.AspNetCore.Mvc;
using RawRabbit.Configuration.Exchange;
using RawRabbit.vNext;
using RawRabbit.vNext.Disposable;
using System.Collections.Generic;
using System.Linq;

namespace Lapiwe.GMS.FrontEnd.Controllers
{
    public class KlantenController : Controller
    {
        private LapiweGarageContext _context;
        private IBusClient _eventbus;

        public KlantenController(LapiweGarageContext context, IBusClient eventbus)
        {
            _context  = context;
            _eventbus = eventbus;
        }

        public IActionResult RegistratieOverzicht()
        {
            return View();
        }

        public IActionResult KlantenOverzicht()
        {
            IEnumerable<Klant> klanten = _context.Klanten.ToList();
            KlantenLijstViewModel alleKlanten = new KlantenLijstViewModel(klanten);

            return View(alleKlanten);
        }

        [HttpPost]
        public IActionResult RegistreerKlant(Klant klant)
        {
            RegistreerKlantCommand command = new RegistreerKlantCommand(klant);

            _eventbus.PublishAsync(command, command.CorrelationID, (config) => {
                config.WithExchange((exchange) =>
                {
                    exchange.WithName("Lapiwe.Eventbus.Default");
                    exchange.WithType(ExchangeType.Topic);
                });
                config.WithRoutingKey("Lapiwe.FE.RegistreerKlantCommand");
            });

            _context.Klanten.Add(klant);
            _context.SaveChanges();

            return RedirectToAction("KlantenOverzicht");
        }
    }
}
