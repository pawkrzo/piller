using System;
using System.Threading.Tasks;

namespace Piller.Services
{
    public class PermanentStorageService : IPermanentStorageService
    {
        public Task<T> GetAsync<T> (int id)
        {
            throw new NotImplementedException ();
        }

        public Task SaveAsync<T> (T entity)
        {
            throw new NotImplementedException ();
        }
    }
}
