using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CoreTest.EntityFrameworkCore
{
    public static class CoreTestDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<CoreTestDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<CoreTestDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
