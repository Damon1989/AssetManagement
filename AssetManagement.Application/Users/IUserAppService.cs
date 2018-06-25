using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AssetManagement.Roles.Dto;
using AssetManagement.Users.Dto;

namespace AssetManagement.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}