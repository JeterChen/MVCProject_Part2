using MVCProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.Service
{
    public abstract class BaseDomainService
    {
        protected IUnitOfWork uok { get; set; }

        public BaseDomainService(IUnitOfWork uok)
        {
            this.uok = uok;
        }
    }
}
