using System;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
 using Infrastructure.Data;
 using Infrastructure.Helper.AutoMapper;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureStartup
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, Action<DbContextOptionsBuilder> options )
        {
            //Register DbContext
            services.AddDbContext<AppDbContext>(options);

            // Register AutoMapper 
            services.AddAutoMapper(typeof(AutoMapperProfiles) /* You can add more Assembly profiles*/);
             services.AddAuthenticationServices();
            services.AddAuthorizationServices();
             // Repository App
            services.AddScoped(typeof(IRepositoryApp<>), typeof(RepositoryApp<>));
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(CulutureServices));
            // security
            services.AddScoped(typeof(ISecurityRepository), typeof(SecurityRepository));
            // custom claim
             services.AddScoped<IUserClaimsPrincipalFactory<User>, CustomClaimsServices>();

            return services;
        }
    }
}