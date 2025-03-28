using CA.Shared.DTOs.InputModels;
using CA.Shared.DTOs.OutputModels;
using Microsoft.AspNetCore.Mvc;

namespace CA.WebHost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        [HttpGet("/users/get-users")]
        public Task<IResult> GetUsers()
        {
            throw new NotImplementedException();
        }

        [HttpGet("/users/get-user/{Id}")]
        public Task<IResult> GetUserById(Guid Id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("/users/get-user-by-username/{username}")]
        public Task<IResult> GetUserByUserName(string username)
        {
            throw new NotImplementedException();
        }

        [HttpGet("/users/get-user-by-email/{email}")]
        public Task<IResult> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        [HttpPut("/users/update-user/{userId}")]
        public Task<IResult> UpdateUser(Guid userId, UserIM user)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("/users/remove-user/{userId}")]
        public Task<IResult> RemoveUser(Guid userId,string deleteString)
        {
            throw new NotImplementedException();
        }
    }
}
