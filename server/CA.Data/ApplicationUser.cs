using CA.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Data
{
    public class ApplicationUser: IdentityUser<Guid>
    {
        public string? FirstName { get; set; }

        public string? SecondName { get; set; }

        public int Age { get; set; }

        public ICollection<Message> Messages { get; set; } = new List<Message>();

        public ICollection<Image> Images { get; set; } = new List<Image>();

        public ICollection<Chat> Recieved { get; set; } = new List<Chat>();

        public ICollection<Chat> Sent { get; set; } = new List<Chat>();
    }
}
