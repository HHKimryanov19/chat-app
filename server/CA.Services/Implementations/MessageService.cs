using CA.Data;
using CA.Services.Contracts;
using CA.Shared;
using CA.Shared.DTOs.InputModels;
using CA.Shared.DTOs.OutputModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Services.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MessageService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Task<bool> CreateMessage(MessageIM message)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMessage(Guid messageId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<MessageOM>> GetByChatId(Guid chatId)
        {
            throw new NotImplementedException();
        }

        public Task<List<MessageOM>> GetByChatIdDate(Guid chatId, DateOnly startDate, DateOnly endDate)
        {
            throw new NotImplementedException();
        }

        public Task<List<MessageOM>> GetByChatIdUserId(Guid chatId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMessage(MessageIM message, Guid messageId)
        {
            throw new NotImplementedException();
        }
    }
}
