using System.Threading.Tasks;
using Abp.Application.Services;
using AssetManagement.Configuration.Dto;

namespace AssetManagement.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}