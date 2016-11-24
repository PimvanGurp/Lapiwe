using System;

namespace Entities
{
    public class DomainEntity
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool Processed { get; private set; }

        public void MarkProcessed()
        {
            Processed = true;
        }
    }
}