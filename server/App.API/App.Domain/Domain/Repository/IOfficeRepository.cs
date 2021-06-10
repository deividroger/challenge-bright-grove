using App.Context.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Context.Domain.Repository
{
    public interface IOfficeRepository
    {
        Task<IEnumerable<Office>> GetAllOffices();
        Task<IEnumerable<Office>> GetOfficesByStreetName(string streetName);
    }

}

