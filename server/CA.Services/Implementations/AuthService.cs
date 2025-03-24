using CA.Data;
using CA.Services.Contracts;
using CA.Shared.DTOs.InputModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace CA.Services.Implementations
{
    public class AuthService: IAuthService
    {
        public IConfiguration config { get; set; }

        public UserManager<ApplicationUser> userManager { get; set; }

        public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this.config = configuration;
            this.userManager = userManager;
        }

        private async Task<string> CreateToken(ICollection<Claim> authClaims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var sectoken = new JwtSecurityToken(null, expires: DateTime.Now.AddHours(2), signingCredentials: credentials, claims: authClaims);

            var token = new JwtSecurityTokenHandler().WriteToken(sectoken);

            return token;
        }

        public async Task<bool> Register(UserIM user)
        {
            var userExist = await this.userManager.FindByEmailAsync(user.Email);
            if (userExist != null)
            {
                return false;
            }

            string finalUserName = string.Empty;
            if (user.UserName == string.Empty)
            {
                finalUserName = user.FirstName + "" + user.SecondName;
            }
            else
            {
                finalUserName = user.UserName;
            }

            ApplicationUser newUser = new ApplicationUser()
            {
                    UserName = finalUserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    SecondName = user.SecondName,
                    Age = user.Age,
                    SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await this.userManager.CreateAsync(newUser, user.Password);
            if(!result.Succeeded)
            {
                return false;
            }

            return true;
        }

        public async Task<string> Login(LoginIM login)
        {
            var user = await this.userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                throw new Exception("Invalid creditinals");
            }

            var passwordChecker = await this.userManager.CheckPasswordAsync(user, login.Password);
            if (!passwordChecker)
            {
                throw new Exception("Invalid creditinals");
            }

            var userRoles = await this.userManager.GetRolesAsync(user);

            var authClaims = await this.userManager.GetClaimsAsync(user);
            authClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            string token = await CreateToken(authClaims);

            return token;
        }
    }
}
