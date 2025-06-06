﻿using CA.Data;
using CA.Shared.DTOs.InputModels;
using CA.Shared.DTOs.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Services.Contracts
{
    interface IUserService
    {
        Task<List<UserOM>> GetUsers();

        Task<UserOM> GetUserById(Guid? Id);

        Task<UserOM> GetUserByUserName(string username);

        Task<UserOM> GetUserByEmail(string email);

        Task<bool> UpdateUser(Guid? userId, UserIM user);

        Task<bool> RemoveUser(Guid? userId, string deleteString);
    }
}
