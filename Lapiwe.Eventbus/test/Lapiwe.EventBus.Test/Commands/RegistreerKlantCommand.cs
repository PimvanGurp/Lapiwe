using Lapiwe.Common;

namespace Lapiwe.EventbusClient.Test.Commands
{
    public class RegistreerKlantCommand : DomainCommand
    {
        public string KlantNaam { get; private set; }

        public RegistreerKlantCommand(string klantNaam)
        {
            KlantNaam = klantNaam;
        }
    }
}
