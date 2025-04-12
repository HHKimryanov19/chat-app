using CA.Data;
using CA.Services.Implementations;
using CA.Shared.DTOs.InputModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CA.WebHost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController
    {
        public readonly AuthService authServices;

        public AuthController(UserManager<ApplicationUser> userManager,IConfiguration config)
        {
            this.authServices = new AuthService(userManager, config);
        }


        [HttpPost("/auth/user-login")]
        public async Task<IResult> Login([FromBody] LoginIM loginModel)
        {
            try
            {
                var token = await authServices.Login(loginModel);
                return Results.Ok(token);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new
                {
                    Status = "user-login-failed",
                    Message = ex.Message,
                });
            }
        }

        [HttpPost("/auth/user-register")]
        public async Task<IResult> Register([FromBody] UserIM userIM)
        {
            try
            {
                var result = await this.authServices.Register(userIM);

                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new
                {
                    Status = "user-register-failed",
                    Message = ex.Message,
                });
            }
        }
    }
}
