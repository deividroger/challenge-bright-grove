using App.API.Dto;
using App.Context.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        
        [SwaggerResponse(200, Type = typeof(IEnumerable<UserDto>))]
        public async Task<IEnumerable<UserDto>> GetUsers([FromQuery]string officeIds)
            => _mapper.Map<IEnumerable<UserDto>>(await _userService.GetUsers(officeIds));

    }
}
