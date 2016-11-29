
using Lapiwe.OnderhoudService.Export;
using Microsoft.AspNetCore.Mvc;

namespace Lapiwe.OnderhoudService.Facade.Controllers
{
    [Route("api/[controller]")]
    public class OnderhoudController : Controller
    {

        public OnderhoudController()
        {

        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]RegisteerOnderhoudOpdrachtCommand value)
        {

        }
    }

}