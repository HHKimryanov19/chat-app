using CA.Shared.DTOs.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CA.Services.Contracts
{
    interface IAuthService
    {
        Task<string> Login(LoginIM login);

        Task<bool> Register(UserIM user);
    }
}
