using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Shared.DTOs.OutputModels
{
    public class ImageOM
    {
        public Guid Id { get; set; }

        public byte[] Content { get; set; } = default!;

        public Guid UserId { get; set; }

        public DateTime SendOn { get; set; }
    }
}
