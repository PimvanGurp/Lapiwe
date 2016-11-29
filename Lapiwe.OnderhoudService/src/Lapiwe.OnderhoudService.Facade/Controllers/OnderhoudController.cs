
using Lapiwe.Common.Domain;
using Lapiwe.Common.Infastructure;
using Lapiwe.OnderhoudService.Export;
using Lapiwe.OnderhoudService.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

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

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string>() { "Get", "Success"};
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(typeof(OkResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FunctionalError), (int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody]RegisteerOnderhoudOpdrachtCommand command)
        {
            if (ModelState.IsValid && command != null)
            {
                return Ok();
            }

            return BadRequest();
        }
    }

}