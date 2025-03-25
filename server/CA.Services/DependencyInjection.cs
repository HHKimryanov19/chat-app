using CA.Services.Contracts;
using CA.Services.Identity.Services;
using CA.Services.Implementations;
using CA.Shared;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IChatService,ChatService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
