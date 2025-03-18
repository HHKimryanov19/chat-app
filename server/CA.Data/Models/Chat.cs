using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Data.Models
{
    public class Chat
    {
        public ApplicationUser? FirstUser { get; set; }

        public Guid? FirstUserId { get; set; }

        public ApplicationUser? SecondUser { get; set; }

        public Guid? SecondUserId { get; set; }

        public DateTime LastMessageDate { get; set; }

        public byte[] Image { get; set; } = default!;
    }
}