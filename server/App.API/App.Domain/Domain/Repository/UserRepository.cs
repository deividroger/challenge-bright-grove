using App.Context.Domain.Models;
using App.Context.Infra.Data;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Context.Domain.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDataContext _appContext;

        public UserRepository(AppDataContext appContext) => _appContext = appContext;

        public async Task<IEnumerable<User>> GetUser(Guid[] officeIds)
             => await _appContext.Users
                    .Where(o => officeIds.Contains(o.Office.Id))
                    .Include(o => o.Office)
                    .ToListAsync();

        public async Task<IEnumerable<UserRole>> GetUsersRoles(Guid[] userIds)
            => await _appContext.UserRoles
                .Where(x => userIds.Contains(x.UserId))
                .Include(o => o.Role).ToListAsync();

    }
}
