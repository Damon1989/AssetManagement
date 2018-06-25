using System.Threading.Tasks;
using Abp.Application.Services;
using AssetManagement.Authorization.Accounts.Dto;

namespace AssetManagement.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
