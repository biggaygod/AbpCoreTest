using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CoreTest.Authorization;

namespace CoreTest
{
    [DependsOn(
        typeof(CoreTestCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class CoreTestApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<CoreTestAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(CoreTestApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
