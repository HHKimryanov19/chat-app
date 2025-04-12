using CA.Data;
using CA.Data.Models;
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


//check for null
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

        public async Task<bool> CreateMessage(MessageIM message, Guid? userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var chat = await _context.Chats.FindAsync(message.ChatId);

            if (chat == null || user == null)
            {
                return false;
            }

            if (chat.FirstUserId != userId && chat.SecondUserId != userId)
            {
                return false;
            }

            Message newMessage = new Message()
            {
                SendBy = user,
                Text = message.Text,
                SendOn = DateTime.Now,
                Chat = chat,
            };

            chat.LastMessageDate = newMessage.SendOn;
            _context.Chats.Update(chat);
            await _context.Messages.AddAsync(newMessage);
            await _context.SaveChangesAsync();
            return true;
        }

        //to do: last added message deleted
        public async Task<bool> DeleteMessage(Guid messageId, Guid? userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var message = await _context.Messages.FindAsync(messageId.ToString());

            if (message == null || user == null)
            {
                return false;
            }

            if (message.SendBy != user)
            {
                return false;
            }

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
            return true;
        }

        //to do: try to implement pagination 3-5
        public async Task<List<MessageOM>> GetByChatId(Guid chatId, Guid? userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var chat = await _context.Chats.FindAsync(chatId.ToString());

            if (chat == null || user == null)
            {
                return new List<MessageOM>();
            }

            if (chat.FirstUserId != userId && chat.SecondUserId != userId)
            {
                return new List<MessageOM>();
            }

            var messages = await _context.Messages.Where(m => m.ChatId == chatId).ToListAsync();

            return messages.Adapt<List<MessageOM>>();
        }

        public async Task<List<MessageOM>> GetByChatIdDate(Guid chatId, Guid? userId, DateTime startDate, DateTime? endDate)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var chat = await _context.Chats.FindAsync(chatId.ToString());

            if (chat == null || user == null)
            {
                return new List<MessageOM>();
            }

            if (chat.FirstUserId != userId && chat.SecondUserId != userId)
            {
                return new List<MessageOM>();
            }

            endDate = endDate == null ? DateTime.Now : endDate;
            var messages = await _context.Messages
                .Where(m => m.ChatId == chatId)
                .Where(m => m.SendOn > startDate && m.SendOn < endDate)
                .ToListAsync();

            return messages.Adapt<List<MessageOM>>();
        }

        public async Task<List<MessageOM>> GetByChatIdUserId(Guid chatId, Guid? userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var chat = await _context.Chats.FindAsync(chatId.ToString());

            if (chat == null || user == null)
            {
                return new List<MessageOM>();
            }

            if (chat.FirstUserId != userId && chat.SecondUserId != userId)
            {
                return new List<MessageOM>();
            }

            var messages = await _context.Messages
                .Where(m => m.ChatId == chatId)
                .Where(m => m.UserId == userId)
                .ToListAsync();

            return messages.Adapt<List<MessageOM>>();
        }

        public async Task<bool> UpdateMessage(MessageIM newInfo, Guid messageId, Guid? userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var message = await _context.Messages.FindAsync(messageId.ToString());

            if (message == null || user == null)
            {
                return false;
            }

            if (message.UserId != userId)
            {
                return false;
            }

            message.Text = newInfo.Text;
            _context.Messages.Update(message);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
