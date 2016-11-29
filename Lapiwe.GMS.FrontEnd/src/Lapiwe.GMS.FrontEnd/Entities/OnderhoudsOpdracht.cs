using Lapiwe.Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lapiwe.GMS.FrontEnd.Entities
{
    public class OnderhoudsOpdracht : DomainEntity
    {
        [Key]
        public long ID { get; set; }
        public string Kenteken { get; set; }

        public OnderhoudsOpdracht(Guid guid) : base(guid)
        {

        }
    }
}
