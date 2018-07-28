using Autofac;
using MVCProject.Data.Entity;
using MVCProject.Infrastructure;
using MVCProject.Service.CustomerService;
using MVCProject.Service.Repository;
using System.Reflection;

namespace MVCProject.Service
{
    public class DomainModelModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //--------------------------------------------NEW Start
            var domainAssembly = typeof(ICustomerServices).Assembly;
            Assembly repAssembly = typeof(CustomerRepository).Assembly;

            builder.RegisterAssemblyTypes(domainAssembly)
                .Where(t => t.Name.EndsWith("Services"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(domainAssembly, repAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            //--------------------------------------------NEW END
            //installation localization service
            //安裝本地化服務
            //builder.RegisterType<CustomerServices>()
            //    .As<ICustomerServices>()
            //    .InstancePerLifetimeScope();

            // builder.RegisterType<UnitofWord>()
            //.InstancePerLifetimeScope();

            builder.RegisterType<NORTHWNDEntities>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();
        }
    }
}
