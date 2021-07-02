using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Dtos.Auth;
 using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly AppDbContext _db;
         

        public SecurityRepository(AppDbContext db)
        {
            _db = db;
            
        }
        public async Task<IEnumerable<UserListDto>> GetUsersRoles() {

            var users = await (from user in _db.Users
                               select new UserListDto
                               {
                                   Name = user.FirstName + " " + user.MiddelName + " " + user.LastName,
                                   PhoneNumber = user.PhoneNumber,
                                   UserName = user.UserName,
                                   Id = user.Id,
                                    rolesName= string.Join(",", (from userRole in user.UserRole
                                                               join role in _db.Roles
                                                               on userRole.RoleId equals role.Id
                                                               select role
                                          ).ToList())
        }
                         ).ToListAsync();

            return users;
        }

        
    }
}
