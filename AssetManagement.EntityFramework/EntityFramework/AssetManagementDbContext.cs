using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using AssetManagement.Authorization.Roles;
using AssetManagement.Authorization.Users;
using AssetManagement.Depts;
using AssetManagement.MultiTenancy;
using AssetManagement.Vocabularies;

namespace AssetManagement.EntityFramework
{
    public class AssetManagementDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE:
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */

        public AssetManagementDbContext()
            : base("Default")
        {
        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in AssetManagementDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of AssetManagementDbContext since ABP automatically handles it.
         */

        public AssetManagementDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        //This constructor is used in tests
        public AssetManagementDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {
        }

        public AssetManagementDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deptment>().ToTable("basic_Departments");
            modelBuilder.Entity<Vocabulary>().ToTable("basic_Vocabularies");
            modelBuilder.Entity<VocabularyItem>().ToTable("basic_VocabularyItems");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Deptment> Deptment { get; set; }
        public DbSet<Vocabulary> Vocabularies { get; set; }
        public DbSet<VocabularyItem> VocabularyItems { get; set; }
    }
}