using App.Context.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Context.Domain.Services
{
    public interface IUserService
    {
        Task< IEnumerable<User>> GetUsers(string officeIds);
    }
}