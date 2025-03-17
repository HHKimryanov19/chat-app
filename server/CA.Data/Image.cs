using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Data
{
    public class Image
    {
        public byte[] Picture { get; set; } = default!;

        public ApplicationUser? SendBy { get; set; }

        public Guid UserId { get; set; }

        public DateTime SendOn { get; set; }
    }
}
