using Lapiwe.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lapiwe.OnderhoudService.Export
{
    public class RegisteerOnderhoudOpdrachtCommand : DomainCommand
    {
        public Guid OnderhoudsOpdrachtGuid { get; set; }

        public RegisteerOnderhoudOpdrachtCommand(Guid onderhoudsGuid)
        {
            OnderhoudsOpdrachtGuid = onderhoudsGuid;
        }
    }
}
