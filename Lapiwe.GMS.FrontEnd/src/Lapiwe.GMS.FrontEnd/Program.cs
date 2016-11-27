using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using RawRabbit.vNext;
using RawRabbit.vNext.Disposable;
using Lapiwe.KlantBeheerService.Export.Events;
using Lapiwe.GMS.FrontEnd.EventHandlers;
using RawRabbit.Configuration.Exchange;
using Lapiwe.GMS.Frontend.DAL;

namespace Lapiwe.GMS.FrontEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            SetupEventSubscribers(host);

            host.Run();
        }

        private static void SetupEventSubscribers(IWebHost host)
        {
            IBusClient eventbus = BusClientFactory.CreateDefault();
            var handler = new KlantGeregistreerdEventHandler((LapiweGarageContext) host.Services.GetService(typeof(LapiweGarageContext)));

            //eventbus.SubscribeAsync<KlantGeregistreerdEvent>((request, context) => handler.Handle(request), (config) => {
            //    config.WithExchange((exchange) =>
            //    {
            //        exchange.WithName("Lapiwe.Eventbus.Events");
            //        exchange.WithType(ExchangeType.Topic);
            //    });
            //    config.WithRoutingKey("Lapiwe.FE.KlantGeregistreerdEvent");
            //});
        }
    }
}
