using Autofac;
using Autofac.Configuration;
using Autofac.Integration.Mvc;
using Microsoft.Extensions.Configuration;
using MVCProject.Service;
using MVCProject.Service.CustomerService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCProject
{
    public static class AutofacConfig
    {
        public static void Register()
        {
            ////======================Old Code start=============================////

            var builder = new ContainerBuilder();
            var config = new ConfigurationBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // MVC - OPTIONAL : Register model binders that require DI.
            // MVC - 可選：註冊需要DI的模型粘合劑。
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            //MVC - OPTIONAL : Register web abstractions like HttpContextBase.
            //MVC - 可選：註冊Web抽像如HttpContextBase。
            builder.RegisterModule<AutofacWebTypesModule>();

            //MVC - OPTIONAL : Enable property injection in view pages.
            //MVC - 可選：在視圖頁面中啟用屬性注入。
            builder.RegisterSource(new ViewRegistrationSource());

            //MVC - OPTIONAL : Enable property injection into action filters.
            //MVC - 可選：啟用屬性注入動作過濾器。
            builder.RegisterFilterProvider();

            //installation localization service
            //安裝本地化服務
            string basePath = System.AppDomain.CurrentDomain.BaseDirectory;
            //設定成root路徑
            config.SetBasePath(basePath);

            //參數是與root路徑相對的位置
            config.AddJsonFile("autofac.json");

            //透過Config產生Module
            var module = new ConfigurationModule(config.Build());

            //將Module註冊到Container內
            builder.RegisterModule(module);

            ////======================Old Code end=============================////

            ////======================Old Code start=============================////
            //Set the dependency resolver to be Autofac.
            //var container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            ////======================Old Code end=============================////

            //builder.RegisterType<CustomerServices>()
            //    .As<ICustomerServices>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<UnitofWord>()
            //  .InstancePerLifetimeScope();


            //MVC - Set the dependency resolver to be Autofac.
            //MVC - 將依賴關係解析器設置為Autofac。


            //ContainerBuilder builder = new ContainerBuilder();

            ////Controllers, 必須註冊Controller, 才能在Controller裡面做依賴注入
            //builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //Assembly Service = Assembly.Load("MVCProject.Service");
            //Assembly Infrastructure = Assembly.Load("MVCProject.Infrastructure");
            //Assembly Data = Assembly.Load("MVCProject.Data");


            //builder.RegisterAssemblyTypes(Service).AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(Infrastructure).AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(Data).AsImplementedInterfaces();



            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


        }

    }
}
