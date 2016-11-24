using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lapiwe.GMS.FrontEnd.Entities
{
    public class Bestuurder : DomainEntity
    {
        [Key]
        public int ID { get; set; }
        
        public string Voornaam { get; set; }

        public string TussenVoegsel { get; set; }

        public string Achternaam { get; set; }

        public string Adres { get; set; }

        public string Postcode { get; set; }

        public string Woonplaats { get; set; }

        public string Telefoonnummer { get; set; }

        public string Emailadres { get; set; }

        public string FullName()
        {
            return $"{Voornaam.First()}. {TussenVoegsel} {Achternaam}";
        }
    }
}
