using CA.Services.Contracts;
using CA.Shared.DTOs.InputModels;
using CA.Shared.DTOs.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Services.Implementations
{
    public class ImageService : IImageService
    {
        public Task<bool> Create(ImageIM image)
        {
            throw new NotImplementedException();
        }

        public Task<List<ImageOM>> GetByChatId(Guid chatId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(Guid chatId, Guid imageId)
        {
            throw new NotImplementedException();
        }
    }
}
