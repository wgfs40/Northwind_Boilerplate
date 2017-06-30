using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Wind.Northwind.EntityFramework;

namespace Wind.Northwind.Migrator
{
    [DependsOn(typeof(NorthwindDataModule))]
    public class NorthwindMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<NorthwindDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}