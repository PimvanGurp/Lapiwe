using System;

namespace Lapiwe.KlantBeheerService.Export.Entities
{
    public class Klant
    {
        public Guid Id;

        public Klant()
        {
            Id = Guid.NewGuid();
        }
    }
}
