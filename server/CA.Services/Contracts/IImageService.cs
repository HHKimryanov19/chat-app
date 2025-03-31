using CA.Shared.DTOs.InputModels;
using CA.Shared.DTOs.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Services.Contracts
{
    internal interface IImageService
    {
        Task<List<ImageOM>> GetByChatId(Guid? userId, Guid chatId);

        Task<List<ImageOM>> GetByChatIdUserId(Guid chatId, Guid? userId);

        Task<bool> Remove(Guid? userId, Guid chatId, Guid imageId);

        Task<bool> Create(Guid? userId, ImageIM image);
    }
}
