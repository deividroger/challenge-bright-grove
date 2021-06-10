using App.Context.Domain.Models;
using App.Context.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Context.Domain.Repository
{
    public class OfficeRepository : IOfficeRepository
    {

        private readonly AppDataContext _appContext;

        public OfficeRepository(AppDataContext appContext) => _appContext = appContext;

        public async Task<IEnumerable<Office>> GetAllOffices()
            => await _appContext.Offices.ToListAsync();

        //public async Task<IEnumerable<Office>> GetOfficesByStreetName(string streetName)
        //    => await _appContext.Offices.Where(x => x.Address.Contains(streetName)).ToListAsync();

        public async Task<IEnumerable<Office>> GetOfficesByStreetName(string streetName)
            => await (from c in _appContext.Offices
                      where EF.Functions.Like(c.Address.ToLower(), $"%{streetName.ToLower()}%")
                      select c).ToListAsync();

    }

}

