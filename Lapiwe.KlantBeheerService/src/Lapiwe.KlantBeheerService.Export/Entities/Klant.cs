using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Lapiwe.Common;

namespace Lapiwe.KlantBeheerService.Export.Entities
{
    public class Klant : DomainEntity
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
