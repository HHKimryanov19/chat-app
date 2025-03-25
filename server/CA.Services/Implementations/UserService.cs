using CA.Services.Contracts;
using CA.Shared.DTOs.InputModels;
using CA.Shared.DTOs.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Services.Implementations
{
    class UserService : IUserService
    {
        public Task<UserOM> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserOM>> GetUserById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<UserOM> GetUserByUserName(string username)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserOM>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveUser(string deleteString)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUser(UserIM user)
        {
            throw new NotImplementedException();
        }
    }
}
