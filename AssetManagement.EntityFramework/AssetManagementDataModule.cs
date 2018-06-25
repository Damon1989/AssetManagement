using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using AssetManagement.EntityFramework;

namespace AssetManagement
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(AssetManagementCoreModule))]
    public class AssetManagementDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AssetManagementDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
