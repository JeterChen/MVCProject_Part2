using AutoMapper;
using MVCProject.Service.ModelMapper.E2V;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.Service.Thirdparty
{
    public static class DomainModelInitializer
    {
        public static void Initialize()
        {
            //初始化Domain Container
            //暫時不使用Event、EventHandler
            //DomainContainer.Initialize();

            //初始化AutoMapper
            Mapper.Initialize(c =>
            {
                var profiles = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => t.Name.EndsWith("Profile"));

                foreach (var profile in profiles)
                {
                    var obj = Activator.CreateInstance(profile);
                    c.AddProfile((Profile)obj);
                }
            });

        }
    }
}
