using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private Guid  UserId = Guid.Parse("C22694B8-42A2-4115-9631-1C2D1E2AC5F7");

        public void Configure(EntityTypeBuilder<User> builder)
        {
           
            builder.ToTable("User");
            var admin = new User
            {
                Id = UserId,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                FirstName = "admin",
                LastName = "admin",
                MiddelName = "admin",
                Email = "Admin@eg.com",
                NormalizedEmail = "ADMIN@EG.COM",
                PhoneNumber = "01027409328",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = new Guid().ToString("D"),
                  };
            admin.PasswordHash   = new PasswordHasher<User>().HashPassword(admin, "admin");
             builder.HasData(admin  );
        }
    }
}
