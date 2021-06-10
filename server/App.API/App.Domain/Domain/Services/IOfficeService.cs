using App.Context.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Context.Domain.Services
{
    public interface IOfficeService
    {
        Task<IEnumerable<Office>> GetOffices();
        
        Task<IEnumerable<Office>> GetOfficesByStreetName(string streetName);
    }
}
