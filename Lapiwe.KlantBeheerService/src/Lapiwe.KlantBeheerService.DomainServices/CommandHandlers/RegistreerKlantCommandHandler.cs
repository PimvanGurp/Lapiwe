using Lapiwe.Common;
using Lapiwe.KlantBeheerService.Export.Commands;
using RawRabbit.vNext;
using RawRabbit;
using Lapiwe.KlantBeheerService.Export.Events;
using System.Threading.Tasks;
using RawRabbit.Configuration.Exchange;

namespace Lapiwe.KlantBeheerService.DomainServices.CommandHandlers
{
    public class RegistreerKlantCommandHandler : ICommandHandler<RegistreerKlantCommand>
    {
        private IBusClient _eventbus;

        public RegistreerKlantCommandHandler()
        {
            _eventbus = BusClientFactory.CreateDefault();
        }

        public async Task Handle(RegistreerKlantCommand domainCommand)
        {
            System.Console.WriteLine("Handle Called: " + domainCommand.NieuweKlant.Id);
            KlantGeregistreerdEvent domainEvent = new KlantGeregistreerdEvent(domainCommand.NieuweKlant.Id);
            await _eventbus.PublishAsync(domainEvent, domainEvent.CorrelationID, (config) => {
                config.WithExchange((exchange) =>
                {
                    exchange.WithName("Lapiwe.Eventbus.Events");
                    exchange.WithType(ExchangeType.Topic);
                });
                config.WithRoutingKey("Lapiwe.FE.KlantGeregistreerdEvent");
            });
        }
    }
}
