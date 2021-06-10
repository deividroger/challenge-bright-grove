using App.Context.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Context.Domain.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserRole>> GetUsersRoles(Guid[] userIds);
        Task<IEnumerable<User>> GetUser(Guid[] officeIds);
    }
}
