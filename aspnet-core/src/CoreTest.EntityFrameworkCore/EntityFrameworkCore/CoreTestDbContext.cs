using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using CoreTest.Authorization.Roles;
using CoreTest.Authorization.Users;
using CoreTest.MultiTenancy;
using CoreTest.Entities.Customer;
using CoreTest.Entities.Base;

namespace CoreTest.EntityFrameworkCore
{
    public class CoreTestDbContext : AbpZeroDbContext<Tenant, Role, User, CoreTestDbContext>
    {
        #region 基础数据
        public DbSet<BaseCity> BaseCity { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Dictionary> Dictionary { get; set; }
        public DbSet<DictionaryDetail> DictionaryDetail { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<PayType> PayType { get; set; }
        public DbSet<SignBody> SignBody { get; set; }
        #endregion

        #region 客户品牌
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerBrand> CustomerBrand { get; set; }
        public DbSet<CustomerContact> CustomerContact { get; set; }
        public DbSet<CustomerFile> CustomerFile { get; set; }
        #endregion


        public CoreTestDbContext(DbContextOptions<CoreTestDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region 基础数据多重主键
            modelBuilder.Entity<BaseCity>().HasKey(u => new { u.Id, u.CountryCode });
            modelBuilder.Entity<Country>().HasKey(u => new { u.Id, u.CountryCode });
            modelBuilder.Entity<Department>().HasKey(u => new { u.Id, u.CountryCode });
            modelBuilder.Entity<Employee>().HasKey(u => new { u.Id, u.CountryCode });
            modelBuilder.Entity<PayType>().HasKey(u => new { u.Id, u.CountryCode });
            modelBuilder.Entity<SignBody>().HasKey(u => new { u.Id, u.CountryCode });
            #endregion

            #region 客户多重主键
            modelBuilder.Entity<Brand>().HasKey(u => new { u.Id, u.CountryCode });
            modelBuilder.Entity<Customer>().HasKey(u => new { u.Id, u.CountryCode });
            modelBuilder.Entity<CustomerBrand>().HasKey(u => new { u.Id, u.CountryCode });
            modelBuilder.Entity<CustomerContact>().HasKey(u => new { u.Id, u.CountryCode });
            modelBuilder.Entity<CustomerFile>().HasKey(u => new { u.Id, u.CountryCode });
            #endregion
        }
    }

}
