using System;
using System.Collections.Generic;

namespace App.API.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public OfficeDto Office { get; set; }

        public  List<RoleDto> Roles { get; set; }
    }
}
