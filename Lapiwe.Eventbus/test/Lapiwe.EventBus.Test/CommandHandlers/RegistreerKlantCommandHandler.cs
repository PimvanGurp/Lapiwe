using Lapiwe.Common;
using Lapiwe.EventbusClient.Test.Commands;

namespace Lapiwe.EventbusClient.Test.CommandHandlers
{
    public class RegistreerKlantCommandHandler : ICommandHandler<RegistreerKlantCommand>
    {
        public RegistreerKlantCommand CalledWith { get; private set; }
        public int TimesCalled { get; private set; }

        public void Handle(RegistreerKlantCommand domainCommand)
        {
            TimesCalled++;
            CalledWith = domainCommand;
        }
    }
}
