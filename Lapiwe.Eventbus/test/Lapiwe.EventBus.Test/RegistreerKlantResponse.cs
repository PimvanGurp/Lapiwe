using Lapiwe.Common;

namespace Lapiwe.EventBus.Test
{
    public class RegistreerKlantResponse : DomainResponse<int>
    {
        public RegistreerKlantResponse(int n) : base(n)
        {
        }
    }
}