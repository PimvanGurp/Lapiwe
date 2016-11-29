using Lapiwe.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lapiwe.OnderhoudService.Export
{
    public class RegisteerOnderhoudOpdrachtCommand : DomainCommand
    {
        public Guid KlantGuid { get; set; }
        public Guid AutoGuid { get; set; }
        public DateTime AanmeldDatum { get; set; }
        public int Kilometerstand { get; set; }
        public string OpdrachtOmschrijving { get; set; }
    }
}
