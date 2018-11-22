using System.Threading.Tasks;
using CoreTest.Configuration.Dto;

namespace CoreTest.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
