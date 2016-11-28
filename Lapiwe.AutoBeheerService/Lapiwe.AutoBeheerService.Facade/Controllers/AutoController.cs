using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lapiwe.AutoBeheerService.Facade.Controllers
{
    [Route("api/auto")]
    public class AutoController : Controller
    {        
        [HttpPost]
        public void Toevoegen([FromBody]Auto auto)
        {
            // Store auto in db
            // Publish AutoToegevoegdEvent
        }
    }
}
