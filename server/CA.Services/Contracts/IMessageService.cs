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
        Task<List<MessageOM>> GetByChatId(Guid chatId, Guid? userId);

        Task<List<MessageOM>> GetByChatIdUserId(Guid chatId, Guid? userId);

        Task<List<MessageOM>> GetByChatIdDate(Guid chatId, Guid? userId, DateTime startDate, DateTime? endDate);

        Task<bool> CreateMessage(MessageIM message, Guid? userId);

        Task<bool> UpdateMessage(MessageIM newInfo, Guid messageId, Guid? userId);

        Task<bool> DeleteMessage(Guid messageId, Guid? userId);
    }
}