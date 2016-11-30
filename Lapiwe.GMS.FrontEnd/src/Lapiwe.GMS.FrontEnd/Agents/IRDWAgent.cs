using Lapiwe.IS.RDW.Export.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lapiwe.GMS.FrontEnd.Agents
{
    public interface IRDWAgent
    {
        IActionResult KeuringsVerzoek(KeuringsVerzoekCommand domainCommand); 
    }
}
