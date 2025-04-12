using CA.Data;
using CA.Data.Models;
using CA.Services.Implementations;
using CA.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CA.WebHost.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ChatController
    {
        private readonly ChatService _service;

        public ChatController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _service = new ChatService(context, userManager);
        }

        [Authorize]
        [HttpPost("/create-chat")]
        public async Task<IResult> Create([FromRoute]Guid userId, ICurrentUser currentUser)
        {
            try
            {
                var result = await _service.Create(userId, currentUser.Id);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { 
                    Status = "create-chat-failed",
                    Message = ex.Message,
                });
            }
        }

        [Authorize]
        [HttpGet("/get-all-user-chats/{reversed?}")]
        public async Task<IResult> GetByUserId(ICurrentUser currentUser, bool reversed = false)
        {
            try
            {
                var result = await _service.GetByUserId(currentUser.Id, reversed);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { 
                    Status = "get-chats-failed",
                    Message = ex.Message,
                });
            }
        }

        [Authorize]
        [HttpGet("/get-last-user-chats/{count}/{reversed}")]
        public async Task<IResult> GetLastChats(ICurrentUser currentUser,[FromRoute]int count)
        {
            try
            {
                var result = await _service.GetLastChats(currentUser.Id, count);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new
                {
                    Status = "get-chats-failed",
                    Message = ex.Message
                });
            }
        }

        [Authorize]
        [HttpPut("/update-chat-image/{chatId}")]
        public async Task<IResult> Update(ICurrentUser currentUser,[FromRoute]Guid chatId,IFormFile image)
        {
            try
            {
                var result = await _service.Update(currentUser.Id, chatId, image);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { 
                    Status = "update-chat-failed",
                    Message = ex.Message,
                });
            }
        }
    }
}