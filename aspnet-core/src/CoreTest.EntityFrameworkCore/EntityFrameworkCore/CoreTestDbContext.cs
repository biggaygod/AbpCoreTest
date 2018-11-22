using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using CoreTest.Authorization.Roles;
using CoreTest.Authorization.Users;
using CoreTest.MultiTenancy;
using CoreTest.Entities;

namespace CoreTest.EntityFrameworkCore
{
    public class CoreTestDbContext : AbpZeroDbContext<Tenant, Role, User, CoreTestDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Brand> Brand { get; set; }

        public CoreTestDbContext(DbContextOptions<CoreTestDbContext> options)
            : base(options)
        {
        }

        

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Brand>().HasIndex(p => p.Id).IsUnique();
        //}
    }

}
