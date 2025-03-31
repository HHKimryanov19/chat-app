using CA.Data;
using CA.Data.Models;
using CA.Services.Contracts;
using CA.Services.Identity.Services;
using CA.Shared.DTOs.InputModels;
using CA.Shared.DTOs.OutputModels;
using Mapster;
using Microsoft.AspNetCore.Http;
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

        public async Task<bool> Create(Guid userId, Guid? currentUserId)
        {
            var currentUser = await _userManager.FindByIdAsync(currentUserId.ToString());
            var anotherUser = await _userManager.FindByIdAsync(currentUserId.ToString());

            if (currentUser == null || anotherUser == null)
            {
                return false;
            }

            Chat chat = new Chat()
            {
                FirstUserId = currentUserId,
                SecondUserId = userId,
            };

            var result = await _context.Chats.AddAsync(chat);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ChatOM>> GetByUserId(Guid? userId,bool reversed)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return new List<ChatOM>();
            }

            var chats = _context.Chats.Where(c => c.FirstUserId == userId || c.SecondUserId == userId);

            chats = reversed ? chats.OrderBy(c => c.LastMessageDate) : chats.OrderByDescending(c => c.LastMessageDate);

            return chats.ToList().Adapt<List<ChatOM>>();
        }

        public async Task<List<ChatOM>> GetLastChats(Guid? userId,int numberOfChats, bool reversed = false)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return new List<ChatOM>();
            }

            var chats = _context.Chats.Where(c => c.FirstUserId == userId || c.SecondUserId == userId);

            chats = reversed ? chats.OrderBy(c => c.LastMessageDate) : chats.OrderByDescending(c => c.LastMessageDate);

            return chats.Take(numberOfChats).ToList().Adapt<List<ChatOM>>();
        }

        public async Task<bool> Update(Guid? userId, Guid? chatId, IFormFile image)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var chat = await _context.Chats.FindAsync(chatId);

            if (user == null || chat == null)
            {
                return false;
            }

            if (chat.FirstUser != user && chat.SecondUser != user)
            {
                return false;
            }

            if (image is not null)
            {
                var imageStream = new MemoryStream();
                image.CopyTo(imageStream);
                chat.Picture = imageStream.ToArray();
            }

            _context.Chats.Update(chat);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
