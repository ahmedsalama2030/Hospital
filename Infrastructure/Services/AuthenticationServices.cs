using System;
using System.Text;
using AutoMapper.Configuration;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services
{
    public static class AuthenticationServices
    {
        public static void AddAuthenticationServices(this IServiceCollection services)
        {
            IdentityBuilder builder = services.AddIdentityCore<User>(opt =>
            { //Helper functions for configuring identity services.
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 4;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
            });
            // 2- IdentityBuilder config
            builder = new IdentityBuilder(builder.UserType,typeof(Role),builder.Services);
            builder.AddEntityFrameworkStores<AppDbContext>();
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddSignInManager<SignInManager<User>>();


            services.AddAuthentication("Identity.Application")
      .AddCookie("Identity.Application", options =>
     {

         options.LoginPath = new PathString("/auth/Login");
         options.ReturnUrlParameter = "RedirectUrl";
         options.LogoutPath = new PathString("/auth/Logout");
         options.AccessDeniedPath = new PathString("/auth/AccessDenied");
         options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

     });
            // 2- AuthenticationScheme config


        }
    }
}