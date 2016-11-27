using Lapiwe.Common;
using Lapiwe.KlantBeheerService.Export.Entities;

namespace Lapiwe.KlantBeheerService.Export.Commands
{
    public class RegistreerKlantCommand : DomainCommand
    {
        public Klant NieuweKlant { get; private set; }

        public RegistreerKlantCommand(Klant nieuweKlant)
        {
            NieuweKlant = nieuweKlant;
        }
    }
}
