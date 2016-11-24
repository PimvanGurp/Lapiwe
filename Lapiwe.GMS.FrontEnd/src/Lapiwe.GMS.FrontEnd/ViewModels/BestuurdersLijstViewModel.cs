using Lapiwe.GMS.FrontEnd.Entities;
using System.Collections.Generic;

namespace Lapiwe.GMS.FrontEnd.ViewModels
{
    public class BestuurdersLijstViewModel
    {
        public IEnumerable<Bestuurder> Bestuurders { get; set; }

        public BestuurdersLijstViewModel(IEnumerable<Bestuurder> bestuurders)
        {
            Bestuurders = bestuurders;
        }
    }
}
