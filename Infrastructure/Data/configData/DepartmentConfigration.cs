using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class DepartmentConfigration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasMany(a => a.Doctors).WithOne(a => a.Department).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(a => a.DepartmentServices).WithOne(a => a.Department).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
