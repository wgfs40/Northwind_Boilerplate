using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using Wind.Northwind.EntityFramework;

namespace Wind.Northwind
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(NorthwindCoreModule))]
    public class NorthwindDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<NorthwindDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
