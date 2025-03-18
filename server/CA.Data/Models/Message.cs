using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Data.Models
{
    public class Message
    {
        public ApplicationUser? SendBy { get; set; }

        public Guid UserId { get; set; }

        public string? Text { get; set; }

        public DateTime SendOn { get; set; }
    }
}
