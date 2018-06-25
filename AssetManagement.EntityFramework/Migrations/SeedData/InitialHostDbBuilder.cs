using AssetManagement.EntityFramework;
using EntityFramework.DynamicFilters;

namespace AssetManagement.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly AssetManagementDbContext _context;

        public InitialHostDbBuilder(AssetManagementDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
