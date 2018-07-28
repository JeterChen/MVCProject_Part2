using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MVCProject.Service
{
    public class AutofacCommonBuilder
    {
        public static ContainerBuilder Build(string sectionName)
        {
            var config = new ConfigurationBuilder();
            //取得目前專案的路徑，原本預設是在bin的Debug資料夾
            string basePath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            //設定成root路徑
            config.SetBasePath(basePath);

            //參數是與root路徑相對的位置
            config.AddJsonFile($"{sectionName}.json");

            //透過Config產生Module
            var module = new ConfigurationModule(config.Build());

            var builder = new ContainerBuilder();
            //將Module註冊到Container內
            builder.RegisterModule(module);

            return builder;
        }
    }
}
