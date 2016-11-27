using System;

namespace Lapiwe.Common
{
    /// <summary>
    ///     Base class for every domain command
    ///     holding data that can be generated
    ///     at command creation and is part of every command
    /// </summary>
    public abstract class DomainCommand
    {
        public DateTime TimeStamp { get; set; }
        public Guid CorrelationID { get; set; }
        public string RoutingKey { get; set; }

        public DomainCommand()
        {
            TimeStamp = DateTime.Now;
            CorrelationID = Guid.NewGuid();
            RoutingKey = GetType().FullName;
        }
    }
}
