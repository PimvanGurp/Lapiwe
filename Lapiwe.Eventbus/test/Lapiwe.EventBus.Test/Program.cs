using Lapiwe.Eventbus;
using RawRabbit.vNext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lapiwe.EventBus.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LapiweEventbus bus = new LapiweEventbus();
            bus.RPCResponse<RegistreerKlantCommand, int>(null);
            int result = bus.RPCRequest<RegistreerKlantCommand, int>(new RegistreerKlantCommand()).Result;

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
