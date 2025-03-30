using CA.Data;
using CA.Services.Implementations;
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

        [HttpPost("/create-chat")]
        public async Task<IResult> Create()
        {
            return Results.Empty;
        }

        [HttpGet("/get-all-user-chats")]
        public async Task<IResult> GetByUserId()
        {
            return Results.Empty;
        }

        [HttpGet("/get-last-user-chats")]
        public async Task<IResult> GetLastChats()
        {
            return Results.Empty;
        }

        [HttpPut("/update-chat-image")]
        public async Task<IResult> Update()
        {
            return Results.Empty;
        }
    }
}
