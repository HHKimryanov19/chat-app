using CA.Data;
using CA.Services.Contracts;
using CA.Shared;
using CA.Shared.DTOs.InputModels;
using CA.Shared.DTOs.OutputModels;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<UserOM> GetUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new UserOM();
            }

            return user.Adapt<UserOM>();
        }

        public async Task<UserOM> GetUserById(Guid Id)
        {
            var user = await _userManager.FindByIdAsync(Id.ToString());
            if (user == null)
            {
                return new UserOM();
            }

            return user.Adapt<UserOM>();
        }

        public async Task<UserOM> GetUserByUserName(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return new UserOM();
            }

            return user.Adapt<UserOM>();
        }

        public async Task<List<UserOM>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            if (users == null)
            {
                return new List<UserOM>();
            }

            return users.Adapt<List<UserOM>>();
        }

        public async Task<bool> RemoveUser(Guid userId, string deleteString)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return false;
            }

            string? currentDeleteSting = user.UserName + " - " + user.Email;
            if (currentDeleteSting != null && currentDeleteSting != deleteString)
            {
                return false;
            }

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> UpdateUser(Guid userId, UserIM user)
        {
            var currentUser = await _userManager.FindByIdAsync(userId.ToString());
            if (currentUser == null || user == null)
            {
                return false;
            }

            currentUser.FirstName = user.FirstName != null || user.FirstName != "" ? user.FirstName : currentUser.FirstName;
            currentUser.SecondName = user.SecondName != null || user.SecondName != "" ? user.SecondName : currentUser.SecondName;
            currentUser.UserName = user.UserName != null || user.UserName != "" ? user.UserName : currentUser.UserName;
            currentUser.Email = user.Email != null || user.Email != "" ? user.Email : currentUser.Email;
            currentUser.Age = user.Age > 0 ? user.Age: currentUser.Age;

            var result = await _userManager.UpdateAsync(currentUser);
            return result.Succeeded;
        }
    }
}
