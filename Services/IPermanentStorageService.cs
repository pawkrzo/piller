using System;
using System.Threading.Tasks;

namespace Piller.Services
{
    public interface IPermanentStorageService
    {
        Task<T> GetAsync<T> (int id);
        Task SaveAsync<T> (T entity);
    }
}
