using System.Collections.Generic;
using AssetManagement.Roles.Dto;
using AssetManagement.Users.Dto;

namespace AssetManagement.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}