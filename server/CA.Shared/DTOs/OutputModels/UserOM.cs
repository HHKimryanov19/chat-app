using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Shared.DTOs.OutputModels
{
    public class UserOM
    {
        public string? FirstName { get; set; }

        public string? SecondName { get; set; }

        public string? UserName { get; set; }

        public int Age { get; set; }

        public string? Email { get; set; }
    }
}
