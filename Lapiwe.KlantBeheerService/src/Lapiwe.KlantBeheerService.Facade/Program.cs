using Lapiwe.KlantBeheerService.DomainServices.CommandHandlers;
using Lapiwe.KlantBeheerService.Export.Commands;
using RawRabbit.Configuration.Exchange;
using RawRabbit.vNext;
using RawRabbit.vNext.Disposable;
using System;

namespace Lapiwe.KlantBeheerService.Facade
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SetupCommandSubscribers();
         
            Console.ReadKey();
        }

        private static void SetupCommandSubscribers()
        {
            IBusClient eventbus = BusClientFactory.CreateDefault();
            var handler = new RegistreerKlantCommandHandler();

            eventbus.SubscribeAsync<RegistreerKlantCommand>((request, context) => handler.Handle(request), (config) =>
            {
                config.WithExchange((exchange) =>
                {
                    exchange.WithName("Lapiwe.Eventbus.Commands");
                    exchange.WithType(ExchangeType.Topic);
                });
                config.WithRoutingKey("Lapiwe.FE.RegistreerKlantCommand");
            });
        }
    }
}
