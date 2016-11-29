
using Lapiwe.Common.Infastructure;
using Lapiwe.OnderhoudService.Export;
using Lapiwe.OnderhoudService.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Lapiwe.OnderhoudService.Facade.Controllers
{
    [Route("api/[controller]")]
    public class OnderhoudController : Controller
    {
        private IRepository repository;
        private IEventPublisher publisher;

        public OnderhoudController(IRepository repo, IEventPublisher pub)
        {
            repository = repo;
            publisher = pub;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]RegisteerOnderhoudOpdrachtCommand value)
        {

        }
    }

}