using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class UserRolesConfiguration : IEntityTypeConfiguration<UserRole>
    {
        private Guid UserId = Guid.Parse("C22694B8-42A2-4115-9631-1C2D1E2AC5F7");
        private Guid RoleAdminId = Guid.Parse("B22698B1-42A2-4115-9634-1C2D1E2AC5F8");

        public void Configure(EntityTypeBuilder<UserRole> userRole)
        {
             // primary key
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });
            // relation many to many
                userRole.HasOne(ur => ur.Role)
                 .WithMany(r => r.UserRole).HasForeignKey(ur => ur.RoleId)
                 .IsRequired();
                userRole.HasOne(ur => ur.User)
                .WithMany(r => r.UserRole)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            // data
            userRole.HasData(new UserRole
            {
                UserId = UserId,
                RoleId = RoleAdminId,
            });


        }
    }
}
