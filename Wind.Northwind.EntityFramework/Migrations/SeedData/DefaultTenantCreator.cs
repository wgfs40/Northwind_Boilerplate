using System.Linq;
using Wind.Northwind.EntityFramework;
using Wind.Northwind.MultiTenancy;

namespace Wind.Northwind.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly NorthwindDbContext _context;

        public DefaultTenantCreator(NorthwindDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
