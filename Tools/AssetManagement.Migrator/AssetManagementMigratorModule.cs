using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using AssetManagement.EntityFramework;

namespace AssetManagement.Migrator
{
    [DependsOn(typeof(AssetManagementDataModule))]
    public class AssetManagementMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<AssetManagementDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}