using Lapiwe.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lapiwe.EventBus.Test
{
    public class KlantHandler : ICommandHandler<RegistreerKlantCommand>
    {
        public void Handle(RegistreerKlantCommand domainCommand)
        {
            throw new NotImplementedException();
        }

        public DomainResponse<RegistreerKlantResponse> HandleRPC(RegistreerKlantCommand domainCommand)
        {
            return new DomainResponse<RegistreerKlantResponse>(new RegistreerKlantResponse(5));
        }
    }
}
