using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lapiwe.GMS.FrontEnd.Models
{
    public class AutoKlaarmeldenModel
    {
        public string Voornaam { get; set; }

        public string TussenVoegsel { get; set; }

        public string Achternaam { get; set; }

        public string AutoKenteken { get; set; }

        public int KilometerStand { get; set; }

        public string FullName()
        {
            return $"{Voornaam.First()}. {TussenVoegsel} {Achternaam}";
        }
    }
}
