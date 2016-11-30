using Lapiwe.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lapiwe.OnderhoudService.Domain
{
    public class OnderhoudsOpdracht : DomainEntity
    {
        [Key]
        public long ID { get; set; }
        public Guid KlantGuid { get; set; }
        public Guid AutoGuid { get; set; }
        public DateTime AanmeldDatum { get; set; }
        public int Kilometerstand { get; set; }
        public string OpdrachtOmschrijving { get; set; }
        public Status OpdrachtStatus { get; set; }
        public bool Apk { get; set; }


    }
}
