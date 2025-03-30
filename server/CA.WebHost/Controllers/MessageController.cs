using CA.Data;
using CA.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CA.WebHost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController
    {
        private MessageService _service;

        public MessageController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _service = new MessageService(context, userManager);
        }

        [HttpPost("/add-message")]
        public async Task<IResult> AddMessage()
        {
            return Results.Empty;
        }

        [HttpDelete("/delete-message")]
        public async Task<IResult> RemoveMessage()
        {
            return Results.Empty;
        }

        [HttpGet("/get-message-by-chatId")]
        public async Task<IResult> GetByChatId()
        {
            return Results.Empty;
        }

        [HttpGet("/get-message-by-chatId-and-time-period")]
        public async Task<IResult> GetByChatIdDate()
        {
            return Results.Empty;
        }

        [HttpGet("/get-user-message-by-chatId")]
        public async Task<IResult> GetByChatIdUserId()
        {
            return Results.Empty;
        }

        [HttpPut("/update-message")]
        public async Task<IResult> UpdateMessage()
        {
            return Results.Empty;
        }
    }
}
