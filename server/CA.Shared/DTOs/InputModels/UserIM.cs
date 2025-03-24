using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CA.Shared.DTOs.InputModels
{
    public class UserIM
    {
        public string? FirstName { get; set; }

        public string? SecondName { get; set; }

        public string? UserName { get; set; }

        public int Age { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
