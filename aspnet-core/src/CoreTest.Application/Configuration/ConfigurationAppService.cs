using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using CoreTest.Configuration.Dto;

namespace CoreTest.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : CoreTestAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
