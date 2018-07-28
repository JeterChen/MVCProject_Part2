using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commit
        /// </summary>
        /// <returns>受影響筆數</returns>
        int Commit();

        /// <summary>
        /// 非同步 Commit
        /// </summary>
        /// <returns></returns>
        Task CommitAsync();
    }
}
