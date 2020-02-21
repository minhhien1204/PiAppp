using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiApp.Core.Repositories
{
    public interface IRepositoryAsync<TEnitty> : IRepository<TEnitty> where TEnitty : class
    {
        Task<TEnitty> FindAsync(params object[] keyValues);
        Task<bool> DeleteAsync(params object[] keyValues);
    }
}
