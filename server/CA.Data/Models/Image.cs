using CA.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Data.Models
{
    public class Image: Entity
    {
        public byte[] Content { get; set; } = default!;

        public ApplicationUser? SendBy { get; set; }

        public Guid UserId { get; set; }

        public DateTime SendOn { get; set; }

        public required Chat Chat{ get; set; }

        public Guid ChatId { get; set; }
    }
}
