using CA.Data;
using CA.Services.Identity.Services;
using CA.Services.Implementations;
using CA.Shared;
using CA.Shared.DTOs.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CA.WebHost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController
    {
        private readonly ImageService _service;

        public ImageController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _service = new ImageService(context, userManager);
        }

        [Authorize]
        [HttpPost("/add-image")]
        public async Task<IResult> Add([FromForm]ImageIM image, ICurrentUser currentUser)
        {
            try
            {
                var result = await _service.Create(currentUser.Id, image);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new {
                    Status = "create-image-failed",
                    Message = ex.Message
                });
            }
        }

        [Authorize]
        [HttpGet("/get-images-by-chatId/{chatId}")]
        public async Task<IResult> GetByChatId(ICurrentUser currentUser,[FromRoute]Guid chatId)
        {
            try
            {
                var result = await _service.GetByChatId(currentUser.Id,chatId);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new
                {
                    Status = "get-images-failed",
                    Message = ex.Message
                });
            }
        }

        [Authorize]
        [HttpGet("/get-user-images-by-chatId/{chatId}")]
        public async Task<IResult> GetUserImageByChatId(ICurrentUser currentUser,[FromRoute]Guid chatId)
        {
            try
            {
                var result = await _service.GetByChatIdUserId(chatId, currentUser.Id);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new
                {
                    Status = "get-images-failed",
                    Message = ex.Message
                });
            }
        }

        [Authorize]
        [HttpDelete("/remove-image/{chatId}/{imageId}")]
        public async Task<IResult> Remove(ICurrentUser currentUser, [FromRoute]Guid chatId, [FromRoute]Guid imageId)
        {
            try
            {
                var result = await _service.Remove(currentUser.Id,chatId,imageId);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new
                {
                    Status = "remove-image-failed",
                    Message = ex.Message
                });
            }
        }
    }
}
