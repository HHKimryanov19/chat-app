using CA.Services.Contracts;
using CA.Shared.DTOs.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Services.Implementations
{
    public class ChatService : IChatService
    {
        public Task<bool> Create(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChatOM>> GetByUserId(bool reversed = false)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChatOM>> GetLastChats(int numberOfChats, bool reversed = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Guid userId, byte[] image)
        {
            throw new NotImplementedException();
        }
    }
}
