using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AssetManagement.Configuration.Dto;

namespace AssetManagement.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AssetManagementAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
