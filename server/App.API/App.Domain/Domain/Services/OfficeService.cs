using App.Context.Domain.Models;
using App.Context.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Context.Domain.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepository _iOfficeRepository;
        public OfficeService(IOfficeRepository officeRepository) => _iOfficeRepository = officeRepository;

        public async Task<IEnumerable<Office>> GetOffices()
            => await _iOfficeRepository.GetAllOffices();

        public async Task<IEnumerable<Office>> GetOfficesByStreetName(string streetName)
            => await _iOfficeRepository.GetOfficesByStreetName(streetName);
    }
}
