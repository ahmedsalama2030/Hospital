using Core.Dtos.Auth;
 using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
  public  interface ISecurityRepository
    {
        public Task<IEnumerable<UserListDto>> GetUsersRoles();
    }
}
