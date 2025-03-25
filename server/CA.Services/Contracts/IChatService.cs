using CA.Shared.DTOs.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Services.Contracts
{
    internal interface IChatService
    {
        Task<List<ChatOM>> GetByUserId(bool reversed = false);

        Task<List<ChatOM>> GetLastChats(int numberOfChats,bool reversed = false);

        Task<bool> Create(Guid userId);

        Task<bool> Update(Guid userId, byte[] image);
    }
}
