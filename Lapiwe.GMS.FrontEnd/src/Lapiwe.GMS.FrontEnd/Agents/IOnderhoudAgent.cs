using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lapiwe.GMS.FrontEnd.Agents
{
    public interface IOnderhoudAgent
    {
        IActionResult MeldAutoKlaar(string klantnaam, string kenteken, int kilometerstand); 
    }
}
