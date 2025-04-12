using CA.Data;
using CA.Data.Models;
using CA.Services.Identity.Services;
using CA.Services.Implementations;
using CA.Shared;
using CA.Shared.DTOs.InputModels;
using Mapster;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpPost("/add-message")]
        public async Task<IResult> AddMessage([FromForm]MessageIM message, ICurrentUser user)
        {
            try
            {
                var result = await _service.CreateMessage(message, user.Id);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new
                {
                    Status = "create-message-failed",
                    Message = ex.Message,
                });
            }
        }

        [Authorize]
        [HttpDelete("/delete-message/{messageId}")]
        public async Task<IResult> RemoveMessage([FromRoute] Guid messageId, ICurrentUser user)
        {
            try
            {
                var result = await _service.DeleteMessage(messageId, user.Id);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new
                {
                    Status = "remove-message-failed",
                    Message = ex.Message,
                });
            }
        }

        [Authorize]
        [HttpGet("/get-message-by-chatId/{chatId}")]
        public async Task<IResult> GetByChatId([FromRoute] Guid chatId, ICurrentUser user)
        {
            try
            {
                var result = await _service.GetByChatId(chatId, user.Id);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new
                {
                    Status = "get-by-chatId-messages-failed",
                    Message = ex.Message,
                });
            }
        }

        [Authorize]
        [HttpGet("/get-message-by-chatId-time/{chatId}/{startDate}/{endDate?}")]
        public async Task<IResult> GetByChatIdStartEndDate([FromRoute] DateTime startDate, [FromRoute] DateTime endDate, [FromRoute] Guid chatId, ICurrentUser user)
        {
            try
            {
                var result = await _service.GetByChatIdDate(chatId, user.Id, startDate, endDate);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new
                {
                    Status = "get-by-chatId-date-messages-failed",
                    Message = ex.Message,
                });
            }
        }

        [Authorize]
        [HttpGet("/get-messages-by-chatId-userId/{chatId}")]
        public async Task<IResult> GetByChatIdUserId([FromRoute] Guid chatId, ICurrentUser user)
        {
            try
            {
                var result = await _service.GetByChatIdUserId(chatId, user.Id);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new
                {
                    Status = "get-by-chatId-userId-messages-failed",
                    Message = ex.Message,
                });
            }
        }

        [Authorize]
        [HttpPut("/update-message/{messageId}")]
        public async Task<IResult> UpdateMessage([FromForm] MessageIM message, [FromRoute] Guid messageId, ICurrentUser user)
        {
            try
            {
                var result = await _service.UpdateMessage(message, messageId, user.Id);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new
                {
                    Status = "update-message-failed",
                    Message = ex.Message,
                });
            }
        }
    }
}
