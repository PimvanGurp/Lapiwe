using Lapiwe.KlantBeheerService.Export.Entities;
using System.Collections.Generic;

namespace Lapiwe.GMS.FrontEnd.ViewModels
{
    public class KlantenLijstViewModel
    {
        public IEnumerable<Klant> Klanten { get; set; }

        public KlantenLijstViewModel(IEnumerable<Klant> klanten)
        {
            Klanten = klanten;
        }
    }
}
