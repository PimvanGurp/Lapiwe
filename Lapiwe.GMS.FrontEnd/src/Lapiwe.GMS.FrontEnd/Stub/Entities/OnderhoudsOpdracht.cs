using Lapiwe.Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lapiwe.GMS.FrontEnd.Stub.Entities
{
    public class OnderhoudsOpdracht : DomainEntity
    {
        [Key]
        public long ID { get; set; }
        public Guid KlantGuid { get; set; }
        public Guid AutoGuid { get; set; }
        public DateTime AanmeldDatum { get; set; }
        public string Kenteken { get; set; }
        public string Klantnaam { get; set; }
        public string Telefoonnummer { get; set; }
        public int Kilometerstand { get; set; }
        public string OpdrachtOmschrijving { get; set; }
        //public Status OpdrachtStatus { get; set; }
        public bool Apk { get; set; }
    }
}
