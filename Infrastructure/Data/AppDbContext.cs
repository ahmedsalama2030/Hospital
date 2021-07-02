using System.Reflection;
using System.Drawing;
using System;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
 using Microsoft.EntityFrameworkCore;
 
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
 
namespace Infrastructure.Data
{

    public class AppDbContext : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ClinicSchedul> ClinicScheduls { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentService> DepartmentServices { get; set; }
        public DbSet<GeneralSetting> GeneralSettings { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<CommonQuestion> CommonQuestions { get; set; }

        public DbSet<NewsImage> NewsImages { get; set; }
        public DbSet<DepartmentImages> DepartmentImages { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
              modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
         }

    }
}