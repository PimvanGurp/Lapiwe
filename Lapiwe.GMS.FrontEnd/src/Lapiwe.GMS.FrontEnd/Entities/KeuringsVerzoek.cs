using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lapiwe.GMS.FrontEnd.Entities
{
    public class KeuringsVerzoek
    {
        [Key]
        public long ID { get; set; }
        public string Telefoonnummer { get; set; }
        public Guid OnderhoudsOpdrachtGuid { get; set; }

        // Empty constructor for Entity Framework
        [Obsolete]
        public KeuringsVerzoek()
        {

        }

        public KeuringsVerzoek(string telefoonNummer, Guid onderhoudsOpdrachtGuid)
        {
            Telefoonnummer = telefoonNummer;
            OnderhoudsOpdrachtGuid = onderhoudsOpdrachtGuid;
        }
    }
}
