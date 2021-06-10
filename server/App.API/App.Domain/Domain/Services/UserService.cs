using App.Context.Domain.Models;
using App.Context.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Context.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<IEnumerable<User>> GetUsers(string officeIds)
        {
            var ids = ParseOfficeIds(officeIds);

            var usersFromOffices = await _userRepository.GetUser(ids);
            var rolesFromUsers = await _userRepository.GetUsersRoles(usersFromOffices.Select(x => x.Id).ToArray());

            foreach (var userFound in usersFromOffices)
            {
                var roles = rolesFromUsers.Where(x => x.UserId == userFound.Id).ToList();

                if (roles.Any())
                    userFound.SetRoles(roles);

            }
            return usersFromOffices;
        }

        private static Guid[] ParseOfficeIds(string officeIds)
        {
            return officeIds
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(o => Guid.Parse(o))
                .ToArray();
        }
    }
}
