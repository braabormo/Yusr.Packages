using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Yusr.Core.Abstractions.Entities;
using Yusr.Identity.Abstractions.Interfaces;
using Yusr.Identity.Abstractions.Services;
using Yusr.Identity.Services;

namespace Yusr.Identity
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddYusrIdentity<SystemPermissions>(this IServiceCollection services) where SystemPermissions : ISystemPermissions
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPasswordHasher<IUser>, PasswordHasher<IUser>>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IClaimsService, ClaimsService<SystemPermissions>>();

            return services;
        }
    }
}