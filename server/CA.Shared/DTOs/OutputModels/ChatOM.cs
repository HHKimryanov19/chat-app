using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CA.Shared.DTOs.OutputModels
{
    public class ChatOM
    {
        public Guid User { get; set; }

        public DateTime LastMessageDate { get; set; }

        public Guid LastMessageId { get; set; }

        public byte[] Picture { get; set; } = default!;

        public List<MessageOM> Messages { get; set; } = new List<MessageOM>();

        public List<ImageOM> Images { get; set; } = new List<ImageOM>();
    }
}  