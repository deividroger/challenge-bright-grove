using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Context.Domain.Models
{

    public class User
    {
        private List<Role> _roles;

        public User()
        {
            _roles = new List<Role>();
        }

        public Guid Id { get; set; }
        public string Login { get; set; }
        public Office Office { get; set; }
        public List<UserRole> Roles { get; set; }


        public List<Role> UserRoles => _roles;

        public void SetRoles(List<UserRole> roles)
        {
            if (roles.Any())
            {
                Roles = roles;

                _roles.AddRange(Roles.Select(x => x.Role).ToList());
            }
        }
    }
}
