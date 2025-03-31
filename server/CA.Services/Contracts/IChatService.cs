using CA.Shared.DTOs.OutputModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Services.Contracts
{
    internal interface IChatService
    {
        Task<List<ChatOM>> GetByUserId(Guid? userId, bool reversed = false);

        Task<List<ChatOM>> GetLastChats(Guid? userId,int numberOfChats,bool reversed = false);

        Task<bool> Create(Guid userId, Guid? currentUserId);

        Task<bool> Update(Guid? userId, Guid? chatId, IFormFile image);
    }
}
