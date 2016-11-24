

namespace Lapiwe.Common
{
    public class DomainResponse<TResponse>
    {
        public TResponse Body { get; private set; }

        public DomainResponse(TResponse body)
        {
            Body = body;
        }
    }
}
