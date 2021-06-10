using App.API.Dto;
using App.Context.Domain.Models;
using App.Context.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.API.Controllers
{
    [ApiController]
    [Route("offices")]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService _officeService;
        private readonly IMapper _mapper;

        public OfficeController(IOfficeService officeService, IMapper mapper)
        {
            _officeService = officeService;
            _mapper = mapper;
        }

        [HttpGet]
        
        [SwaggerResponse(200, Type = typeof(IEnumerable<OfficeDto>))]
        public async Task<IEnumerable<OfficeDto>> GetOffices([FromQuery] string streetName)
            => GetOffices(await _officeService.GetOfficesByStreetName(streetName));


        private IEnumerable<OfficeDto> GetOffices(IEnumerable<Office> offices) 
            => _mapper.Map<IEnumerable<OfficeDto>>(offices);

    }
}
