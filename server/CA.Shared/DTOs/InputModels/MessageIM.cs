using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Shared.DTOs.InputModels
{
    public class MessageIM
    {
        public string? Text { get; set; }

        public Guid ChatId { get; set; }
    }
}
