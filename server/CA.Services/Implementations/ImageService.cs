using CA.Data;
using CA.Data.Models;
using CA.Services.Contracts;
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
using static System.Net.Mime.MediaTypeNames;

namespace CA.Services.Implementations
{
    public class ImageService : IImageService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ImageService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<bool> Create(Guid? userId, ImageIM image)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var chat = await _context.Chats.FindAsync(image.ChatId);

            if (user == null || chat == null)
            {
                return false;
            }

            if (chat.FirstUser != user && chat.SecondUser != user)
            {
                return false;
            }

            Data.Models.Image newImage = new Data.Models.Image()
            {
                SendBy = user,
                SendOn = DateTime.Now,
                Chat = chat,
            };

            if (image.Content != null)
            {
                var imageStream = new MemoryStream();
                image.Content.CopyTo(imageStream);
                newImage.Content = imageStream.ToArray();
            }

            await _context.Images.AddAsync(newImage);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ImageOM>> GetByChatId(Guid? userId, Guid chatId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var chat = await _context.Chats.FindAsync(chatId);

            if (user == null || chat == null)
            {
                return new List<ImageOM>();
            }

            if (chat.FirstUser != user && chat.SecondUser != user)
            {
                return new List<ImageOM>();
            }

            var images = await _context.Images.Where(c => c.ChatId == chatId).ToListAsync();
            return images.Adapt<List<ImageOM>>();
        }

        public async Task<List<ImageOM>> GetByChatIdUserId(Guid chatId, Guid? userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var chat = await _context.Chats.FindAsync(chatId);

            if (user == null || chat == null)
            {
                return new List<ImageOM>();
            }

            if (chat.FirstUser != user && chat.SecondUser != user)
            {
                return new List<ImageOM>();
            }

            var images = await _context.Images.Where(c => c.ChatId == chatId && c.UserId == userId).ToListAsync();
            return images.Adapt<List<ImageOM>>();
        }

        public async Task<bool> Remove(Guid? userId, Guid chatId, Guid imageId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var chat = await _context.Chats.FindAsync(chatId);
            var image = await _context.Images.FindAsync(imageId);

            if (user == null || chat == null || image == null)
            {
                return false;
            }

            if (chat.FirstUser != user && chat.SecondUser != user)
            {
                return false;
            }

            if(image.ChatId != chatId || image.UserId != userId)
            {
                return false;
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
