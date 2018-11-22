using System.Threading.Tasks;
using Abp.Application.Services;
using CoreTest.Sessions.Dto;

namespace CoreTest.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
