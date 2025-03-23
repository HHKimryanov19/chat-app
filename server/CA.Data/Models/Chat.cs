using CA.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Data.Models
{
    public class Chat: Entity
    {
        public ApplicationUser? FirstUser { get; set; }

        public Guid? FirstUserId { get; set; }

        public ApplicationUser? SecondUser { get; set; }

        public Guid? SecondUserId { get; set; }

        public DateTime LastMessageDate { get; set; }

        public byte[] Picture { get; set; } = default!;

        public ICollection<Image> Media { get; set; } = new List<Image>();

        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}