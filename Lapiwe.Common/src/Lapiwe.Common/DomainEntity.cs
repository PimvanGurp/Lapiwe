using System;

namespace Lapiwe.Common
{
    public class DomainEntity
    {
        public Guid Id { get; set; }
        public ProcessStatus Status { get; private set; }

        public DomainEntity()
        {
            Id = Guid.NewGuid();
            Status = ProcessStatus.Processing;
        }

        public void MarkProcessed()
        {
            Status = ProcessStatus.Success;
        }

        public bool IsProcessed()
        {
            return Status == ProcessStatus.Success;
        }

        public bool IsProcessing()
        {
            return Status == ProcessStatus.Processing;
        }

        public bool HasErrors()
        {
            return Status == ProcessStatus.Error;
        }
    }
}