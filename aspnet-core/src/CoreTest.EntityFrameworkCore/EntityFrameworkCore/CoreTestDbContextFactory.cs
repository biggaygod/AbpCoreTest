using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using CoreTest.Configuration;
using CoreTest.Web;

namespace CoreTest.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class CoreTestDbContextFactory : IDesignTimeDbContextFactory<CoreTestDbContext>
    {
        public CoreTestDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CoreTestDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            CoreTestDbContextConfigurer.Configure(builder, configuration.GetConnectionString(CoreTestConsts.ConnectionStringName));

            return new CoreTestDbContext(builder.Options);
        }
    }
}
