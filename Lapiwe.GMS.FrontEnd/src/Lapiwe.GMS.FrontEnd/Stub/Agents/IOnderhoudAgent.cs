using Lapiwe.IS.RDW.Export.Commands;
using Lapiwe.OnderhoudService.Export;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lapiwe.GMS.FrontEnd.Stub.Agents
{
    public interface IOnderhoudAgent
    {
        IActionResult Toevoegen(RegisteerOnderhoudOpdrachtCommand command);
    }
}
