using Lapiwe.Common;
using Lapiwe.GMS.FrontEnd.Entities;

namespace Lapiwe.GMS.FrontEnd.Export.Commands
{
    public class RegistreerBestuurderCommand : DomainCommand
    {
        public Bestuurder Bestuurder { get; set; }

        public RegistreerBestuurderCommand(Bestuurder bestuurder)
        {
            Bestuurder = bestuurder;
        }
    }
}
