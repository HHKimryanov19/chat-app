using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Shared.DTOs.InputModels
{
    public class ImageIM
    {
        public byte[] Content { get; set; } = default!;

        public Guid ChatId { get; set; }
    }
}
