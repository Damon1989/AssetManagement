using System.Threading.Tasks;
using Abp.Application.Services;
using AssetManagement.Sessions.Dto;

namespace AssetManagement.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
