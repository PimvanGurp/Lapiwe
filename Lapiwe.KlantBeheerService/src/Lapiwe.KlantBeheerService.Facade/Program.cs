using Lapiwe.KlantBeheerService.Facade.EventHandlers;
using Minor.WSA.Common.Contracts;
using Minor.WSA.WSAEventbus;
using System;

namespace Lapiwe.KlantBeheerService.Facade
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (IEventbus eventbus = new Eventbus())
            {
                eventbus.Subscribe(new POCHandler());
                Console.ReadKey();
            }
        }
    }
}
