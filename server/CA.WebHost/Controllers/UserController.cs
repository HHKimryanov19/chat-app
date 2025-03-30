using CA.Shared.DTOs.InputModels;
using CA.Shared.DTOs.OutputModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using CA.Services.Implementations;
using CA.Data;
using Microsoft.AspNetCore.Identity;
using CA.Shared;
using CA.Services.Identity.Services;

namespace CA.WebHost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        private readonly UserService _userService;

        public UserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userService = new UserService(context, userManager);
        }

        [HttpGet("/users/get-users")]
        public async Task<IResult> GetUsers()
        {
            try
            {
                var result = await _userService.GetUsers();
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new
                {
                    Status = "get-all-users-failed",
                    ex.Message,
                });
            }
        }

        [HttpGet("/users/get-user/{Id}")]
        public async Task<IResult> GetUserById(Guid Id)
        {
            try
            {
                var result = await _userService.GetUserById(Id);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new
                {
                    Status = "get-user-failed",
                    ex.Message,
                });
            }
        }

        [HttpGet("/users/get-user-by-username/{userName}")]
        public async Task<IResult> GetUserByUserName(string userName)
        {
            try
            {
                var result = await _userService.GetUserByUserName(userName);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new
                {
                    Status = "get-user-failed",
                    ex.Message,
                });
            }
        }

        [HttpGet("/users/get-user-by-email/{email}")]
        public async Task<IResult> GetUserByEmail(string email)
        {
            try
            {
                var result = await _userService.GetUserByEmail(email);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new
                {
                    Status = "get-user-failed",
                    ex.Message,
                });
            }
        }

        [HttpPut("/users/update-user/{userId}")]
        public async Task<IResult> UpdateUser(Guid userId, [FromBody] UserIM user)
        {
            try
            {
                var result = await _userService.UpdateUser(userId, user);
                return result ? Results.Ok(result) : Results.BadRequest(new 
                { 
                    Status = "update-user-failed", 
                    Message = "Invalid creditinals" 
                });
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new
                {
                    Status = "update-user-failed",
                    ex.Message,
                });
            }
        }

        [HttpDelete("/users/remove-user/{userId}")]
        public async Task<IResult> RemoveUser(Guid userId,[FromBody] string deleteString)
        {
            try
            {
                var result = await _userService.RemoveUser(userId, deleteString);
                return result ? Results.Ok(result) : Results.BadRequest(new
                {
                    Status = "delete-user-failed",
                    Message = "Invalid creditinals"
                });
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new
                {
                    Status = "delete-user-failed",
                    ex.Message,
                });
            }
        }
    }
}
