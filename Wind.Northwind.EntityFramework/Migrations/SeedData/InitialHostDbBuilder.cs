using Wind.Northwind.EntityFramework;
using EntityFramework.DynamicFilters;

namespace Wind.Northwind.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly NorthwindDbContext _context;

        public InitialHostDbBuilder(NorthwindDbContext context)
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
