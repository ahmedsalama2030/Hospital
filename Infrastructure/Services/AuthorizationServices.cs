using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services
{
    public static  class AuthorizationServices
    {
        public static void AddAuthorizationServices(this IServiceCollection services){
             services.AddAuthorization(
                options =>
                {
                    options.AddPolicy("admin", policy => policy.RequireRole("admin"));
                    options.AddPolicy("user", policy => policy.RequireRole("user"));
                    options.AddPolicy("AllowUserAdmin", policy => policy.RequireRole("user","admin"));
                });
        }
    }
}