using CA.Shared.DTOs.InputModels;
using CA.Shared.DTOs.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Services.Contracts
{
    internal interface IMessageService
    {
        Task<List<MessageOM>> GetByChatId(Guid chatId);

        Task<List<MessageOM>> GetByChatIdUserId(Guid chatId, Guid userId);

        Task<List<MessageOM>> GetByChatIdDate(Guid chatId,DateOnly startDate, DateOnly endDate);

        Task<bool> CreateMessage(MessageIM message);

        Task<bool> UpdateMessage(MessageIM message, Guid messageId);

        Task<bool> DeleteMessage(Guid messageId);
    }
}