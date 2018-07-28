using Autofac;
using MVCProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.Test
{
    internal static class TesterContainer
    {
        private static IContainer Container { get; set; }
        private static object lockObj = new object();

        public static IContainer GetContainer
        {
            get
            {
                if (Container == null)
                {
                    lock (lockObj)
                    {
                        ContainerBuilder builder = AutofacCommonBuilder.Build("autofac");

                        Container = builder.Build();
                    }
                }

                return Container;
            }
        }
    }
}
