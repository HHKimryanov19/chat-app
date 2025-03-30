using CA.Data;
using CA.Services.Contracts;
using CA.Shared.DTOs.OutputModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Services.Implementations
{
    public class ChatService : IChatService
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ChatService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Task<bool> Create(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChatOM>> GetByUserId(bool reversed = false)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChatOM>> GetLastChats(int numberOfChats, bool reversed = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Guid userId, byte[] image)
        {
            throw new NotImplementedException();
        }
    }
}
