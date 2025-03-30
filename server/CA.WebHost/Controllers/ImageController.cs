using CA.Data;
using CA.Services.Implementations;
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

        [HttpPost("/add-image")]
        public async Task<IResult> Add()
        {
            return Results.Empty;
        }

        [HttpGet("/get-images-by-chatId")]
        public async Task<IResult> GetByChatId()
        {
            return Results.Empty;
        }

        [HttpGet("/get-user-images-by-chatId")]
        public async Task<IResult> GetUserImageByChatId()
        {
            return Results.Empty;
        }

        [HttpDelete("/remove-image")]
        public async Task<IResult> Remove()
        {
            return Results.Empty;
        }
    }
}
