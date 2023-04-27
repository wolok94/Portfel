using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Contracts.Persistance
{
    public interface IAsyncRepository <T>  where T : class
    {
        public Task<List<T>> GetAll();
        public Task<T> GetById(int id);
        public Task<T> AddAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task<T> DeleteAsync(T entity);
    }
}
