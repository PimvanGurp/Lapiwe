using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lapiwe.GMS.FrontEnd.Agents
{
    public class OnderhoudAgentStub : IOnderhoudAgent
    {
        public IActionResult KeuringsVerzoek(string klantnaam, string kenteken, int kilometerstand)
        {
            return new OkResult();
        }
    }
}
